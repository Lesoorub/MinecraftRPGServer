using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ICollisionProvider
{
    bool hasCollision(v3i position);
}

public interface IPathfinder
{
    bool TryGetPath(v3f from, v3f to, IGetAllowedSteps rules, out v3i[] path);
}

public interface IGetAllowedSteps
{
    bool CanStay(v3f position);
    IEnumerable<AllowedStep> GetAllowedSteps(v3i position);
}

public class AllowedStep
{
    public v3i position;
    public int weigth;

    public AllowedStep(v3i position, int weigth)
    {
        this.position = position;
        this.weigth = weigth;
    }
}


public class SimplePathfinding : ModifiedAStarAlgoritm, IGetAllowedSteps
{
    private readonly v2f entitySize;
    private readonly bool canFly;
    private readonly ICollisionProvider collisionProvider;
    private v3i[] collidedBlocks;
    public SimplePathfinding(ICollisionProvider collisionProvider, int maxPathSteps, v2f entitySize, bool canFly, Player player) : base(maxPathSteps, player)
    {
        this.entitySize = entitySize;
        this.canFly = canFly;
        this.collisionProvider = collisionProvider;

        collidedBlocks = new v3i[Physics.GetMaxVolumeInBlocks(entitySize)];
    }

    public bool TryGetPath(v3f from, v3f to, out v3i[] path)
    {
        return base.TryGetPath(from, to, this, out path);
    }

    public bool CanStay(v3f position)
    {
        if (!canFly)
        {
            return
                collisionProvider.hasCollision(position.RoundToInt + v3i.down) &&
                !collisionProvider.hasCollision(position.RoundToInt) &&
                !collisionProvider.hasCollision(position.RoundToInt + v3i.up);
        }
        else
        {
            return
                !collisionProvider.hasCollision(position.RoundToInt) &&
                !collisionProvider.hasCollision(position.RoundToInt + v3i.up);
        }

        if (canFly)
        {
            Physics.IntersectionWithBlock(collisionProvider, position, entitySize, ref collidedBlocks, out int len);
            return len == 0;
        }
        else
        {
            Physics.IntersectionWithBlock(collisionProvider, position, entitySize, ref collidedBlocks, out int len);
            if (len == 0)
            {
                Physics.IntersectionWithBlock(collisionProvider, position + v3f.down, new v2f(entitySize.x, 1), ref collidedBlocks, out len);
                return len != 0;
            }
            return false;
        }
    }

    public IEnumerable<AllowedStep> GetAllowedSteps(v3i position)
    {
        List<AllowedStep> steps = new List<AllowedStep>();
        for (int x = -1; x <= 1; x++)
            for (int y = -1; y <= 1; y++)
                for (int z = -1; z <= 1; z++)
                {
                    if (Math.Abs(x) + Math.Abs(z) != 1) continue;
                    var pos = (v3f)(position + new v3i(x, y, z));
                    if (CanStay(pos))
                        steps.Add(new AllowedStep(position + new v3i(x, y, z), 1 + Math.Abs(y)));
                }
        return steps;
    }
}

public class ModifiedAStarAlgoritm : IPathfinder
{
    private readonly int maxPathSteps;
    Player player;
    public ModifiedAStarAlgoritm(int maxPathSteps, Player player)
    {
        this.maxPathSteps = maxPathSteps;
        this.player = player;
    }
    public bool TryGetPath(v3f from, v3f to, IGetAllowedSteps rules, out v3i[] path)
    {

        List<v3i> stack = new List<v3i>(128);
        Dictionary<v3i, DWSpoint> map = new Dictionary<v3i, DWSpoint>(128);//Дискретное рабочее поле (ДРП)
        
        void Add(v3i p)
        {
            stack.Add(p);
        }

        Add(from.FloorToInt);
        map.Add(from.FloorToInt, new DWSpoint(null, 0));

        var round_to = to.FloorToInt;
        //if (!rules.CanStay(to))//Если в точку назначения невозможно прийти
        //{
        //    //Поиск близжайшей доступной точки
        //}

        int iterations = 0;
        v3i[] CalculatePath(v3i to_pos)
        {
            List<v3i> result = new List<v3i>(32);

            var dwspoint = map[to_pos];
            result.Add(to_pos);//Добавим конец пути

            while (dwspoint.from_position != null)
            {
                var pos = dwspoint.from_position;
                dwspoint = map[pos];
                result.Add(pos);//Добавляем весь путь не включая начало и конец
            }

            result.Reverse();//Переворачиваем потому что начало пути в конце списка

            Console.WriteLine("iterations=" + iterations);
            return result.ToArray();
        }

        v3i Pop()//O(stack.Length)
        {
            if (stack.Count == 1)
            {
                var result = stack.First();
                stack.Remove(result);
                return result;
            }
            else
            {
                var minw = stack.Select(x => map.TryGetValue(x, out var y) ? x : null ).Where(x => x != null).Min(x => map[x].width);
                GetMin(stack.Where(x => map.TryGetValue(x, out var y) && y.width == minw), x => x, round_to, out var min, out var result);
                stack.Remove(result);
                return result;
            }
        }

        while (stack.Count > 0)//Пока путь не найден
        {
            var el = Pop();
            var w = map[el].width;

            iterations++;

            if (map.ContainsKey(round_to))//Если путь был построен
            {
                //Ищем путь по ранее заполненной карте
                break;
            }

            foreach (var step in rules.GetAllowedSteps(el))//Получение всех возможных шагов
            {
                var neww = step.weigth + w;
                if (neww > maxPathSteps)//Пропускаем шаги, вес которых больше порогового значения
                    continue;
                if (!map.ContainsKey(step.position))//Если в ДРП пусто
                {
                    Add(step.position);
                    map.Add(step.position, new DWSpoint(el, neww));
                }
                else if (map[step.position].width > neww)//Если вес в ДРП больше чем предлогаемый вес
                {
                    map[step.position] = new DWSpoint(el, neww);
                }
            }

            if (iterations > 1024)//Критерий остановки
            {
                break;
            }
        }

        Console.WriteLine("iterations=" + iterations);

        foreach (var m in map)
        {
            Hologram.Create(player, (v3f)m.Key + v3f.down * 0.25f + v3f.one / 2, $"{m.Value.width}", 10);
        }

        if (!map.ContainsKey(round_to))//Если путь не был наден, нужно найти
                                       //близжайшую к нему взвешенную точку
        {
            GetMin(map, x => x.Key, round_to, out var min, out var result);
            round_to = result.Key;
        }

        path = CalculatePath(round_to);
        return true;
    }
    void GetMin<T>(IEnumerable<T> collection, Func<T, v3i> get, v3i point, out double min, out T element)
    {
        element = collection.First();
        min = (point - get(element)).magnitude;
        foreach (var x in collection)
        {
            var dist = (point - get(x)).magnitude;
            if (dist < min)
            {
                element = x;
                min = dist;
            }
        }
    }
    public class DWSpoint
    {
        public v3i from_position;
        public float width;

        public DWSpoint(v3i from_position, float width)
        {
            this.from_position = from_position;
            this.width = width;
        }
    }
}