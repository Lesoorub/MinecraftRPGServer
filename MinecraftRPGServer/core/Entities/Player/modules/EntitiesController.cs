using System.Collections.Generic;
using MineServer;
using System;
using System.Linq;
using Packets.Play;

public class EntitiesController : IModule
{
    Player player;
    EntityView view => player.view;
    NetworkProvider network => player.network;
    RPGServer rpgserver => player.rpgserver;

    public delegate void EntitySpawnArgs(Entity entity);
    public event EntitySpawnArgs OnEntitySpawn;

    public delegate void EntityDespawnArgs(Entity entity);
    public event EntityDespawnArgs OnEntityDespawn;

    public void Init(Player player)
    {
        this.player = player;
        OnEntitySpawn += EntitiesController_OnEntitySpawn;
        OnEntityDespawn += EntitiesController_OnEntityDespawn;
    }


    private void EntitiesController_OnEntitySpawn(Entity entity)
    {
        Console.WriteLine($"Spawn entity with EID={entity.EntityID} {entity.GetType()}");
        if (entity is LivingEntity living)
        {
            lock (living.whoViewMe)
            {
                living.whoViewMe.Add(player);
            }

            living.SendMaxHealth(player.network);
            living.SendEquipments(player.network);
        }
    }
    private void EntitiesController_OnEntityDespawn(Entity entity)
    {
        Console.WriteLine($"Destroy entity with EID={entity.EntityID} {entity.GetType()}");
        if (entity is LivingEntity living)
        {
            lock (living.whoViewMe)
            {
                living.whoViewMe.Remove(player);
            }
        }
    }

    public void Tick()
    {
        if (player.rpgserver.currentTick % 10 == 0)
        {
            UpdateLoadedEntitiesLoad();

            //Обновление метадаты клиента всех видимых ентити
            foreach (var entity in view.entities)
            {
                SendMetadataChanges(entity.Value.entity, entity.Value.PreviousMetadataTime);
                entity.Value.PreviousMetadataTime = Time.Now();
            }
        }
        //Удалить всех кто уже не числится в реестре энтити
        player.entitiesController.UnloadEntities(view.entities
            .Where(x => x.Value.entity.isDestroyed)
            .Select(x => x.Key));
        //Обновление позиций всех загруженных(видимых) энтити
        foreach (var loaded_entity in view.entities)
        {
            var ent = loaded_entity.Value.entity;
            bool PositionChanged = !loaded_entity.Value.PreviousPosition.Equals(ent.Position);
            bool RotationChanged = !loaded_entity.Value.PreviousRotation.Equals(ent.Rotation);
            var idle = (Time.Now() - loaded_entity.Value.PreviousPositionSyncTime) <= 20;
            if (idle)
                PositionChanged = RotationChanged = true;
            if (PositionChanged || RotationChanged)
            {
                if (PositionChanged && RotationChanged)//position and rotataion
                {
                    ent.SendChangePositionAndRotation(network, loaded_entity.Value.PreviousPosition);
                }
                else
                {
                    if (PositionChanged)
                        ent.SendChangePosition(network, loaded_entity.Value.PreviousPosition);
                    else
                        ent.SendRotation(network);
                }
                if (PositionChanged)
                    loaded_entity.Value.PreviousPosition = ent.Position.Clone();
                if (RotationChanged)
                    loaded_entity.Value.PreviousRotation = new v2f(ent.Rotation.x, ent.Rotation.y);
                if (!idle)
                    loaded_entity.Value.PreviousPositionSyncTime = Time.Now();
            }
            if (!ent.Velocity.Equals(new v3f(0, 0, 0)))
            {
                ent.SendVelosity(network);
            }
        }
    }
    /// <summary>
    /// Создает энтити на клиенте
    /// </summary>
    /// <param name="entity"></param>
    public bool LoadEntity(Entity entity)
    {
        if (entity.EntityID == player.EntityID) return false;//Пропускаем себя
        if (view.entities.ContainsKey(entity.EntityID)) return false;//Пропускаем всех уже загруженных
        if (entity is IEntityProtocol protocol)//Выбираем только тех кто в зоне видимости и которых можно создать
        {
            var nets = new NetworkProvider[] { network };
            protocol.SendSpawn(nets);//Создать на клиенте
            view.Add(entity);//Добавить в загруженные
            OnEntitySpawn?.Invoke(entity);
            return true;
        }
        return false;
    }
    public void UnloadEntities(IEnumerable<int> EIDs)
    {
        foreach (var EID in EIDs)
        {
            var entity = player.world.entities.GetByEID(EID);
            if (entity != null)
                OnEntityDespawn?.Invoke(entity);
        }
        SendDestroyEntities(EIDs);//Удалить все выбранные у клиента и из загруженных
    }
    public void UnloadEntity(int EID)
    {
        var entity = player.world.entities.GetByEID(EID);
        if (entity != null)
        {
            OnEntityDespawn?.Invoke(entity);
        }
        SendDestroyEntities(new int[] { EID });//Удалить все выбранные у клиента и из загруженных
    }
    /// <summary>
    /// Создает энтити появившихся в поле зрения клиента и удаляет энтити которых уже нет в поле зрения
    /// </summary>
    public void UpdateLoadedEntitiesLoad()
    {
        var cfg = rpgserver.config;

        //Выгрузить всех энтити вне зоны видимости
        if (view.entities.Count > 0)
        {
            var unloadSqrDistance = Math.Pow(cfg.entities.MaxDrawEntitiesRange + cfg.entities.MaxDrawEntitiesRangeThreshold, 2);
            bool f(KeyValuePair<int, LoadedEntity<Entity>> x) => 
                x.Value.entity.isDestroyed || //Ентити уничтожено
                v3f.SqrDistance(x.Value.entity.Position, player.Position) >= unloadSqrDistance; //Ентити дальше радиуса выгрузки
            if (view.entities.Any(x => f(x)))
                UnloadEntities(view.entities
                    .Where(x => f(x))
                    .Select(x => x.Key));
        }

        //Добавить все энтити находящиеся в зоне видимости
        foreach (var entity in player.GetEntityInRadius(player.Position, cfg.entities.MaxDrawEntitiesRange))
        {
            if (LoadEntity(entity))
            {
                //Отправить метаданные
                SendMetadataChanges(entity);
            }
        }
    }

    public void SendMetadataChanges(Entity entity, long lastupdate = 0)
    {
        var changes = entity.meta.GetMetadataChanges(lastupdate);
        if (changes.Length == 1) return;
        network.Send(new Packets.Play.EntityMetadata()
        {
            EntityID = entity.EntityID,
            Metadata = changes
        });
    }

    public void SendDestroyEntities(IEnumerable<int> entities)
    {
        if (entities.Count() == 0) return;
        network.Send(new DestroyEntities()
        {
            Entities = entities.Select(x => new VarInt(x)).ToArray()
        });
        view.Remove(entities);
    }
}
