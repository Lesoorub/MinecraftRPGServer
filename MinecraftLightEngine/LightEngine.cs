using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLightEngine
{
    public interface ILightWorld
    {
        byte[] GetBlockLightData(int chunk_x, int section_y, int chunk_z);
        byte[] GetSkyLightData(int chunk_x, int section_y, int chunk_z);
        void SetBlockLightData(int chunk_x, int section_y, int chunk_z, byte[] data);
        void SetSkyLightData(int chunk_x, int section_y, int chunk_z, byte[] data);
        byte GetBlockLightPower(int ax, short ay, int az);
        bool IsLightTransparent(int ax, short ay, int az);
    }
    public interface ILightEngine
    {
        byte[] CreateBlockLightData(ILightWorld world, int chunk_x, short chunk_y, int chunk_z);
        byte[] CreateSkyLightData(ILightWorld world, int chunk_x, short chunk_y, int chunk_z);
    }
    public class LightEngine : ILightEngine
    {
        const byte size = 16;
        public byte[] CreateBlockLightData(ILightWorld world, int chunk_x, short chunk_y, int chunk_z)
        {
            byte[,,] buffer = new byte[size, size, size];
            bool[,,] LightMask = new bool[size, size, size];
            int acx = chunk_x * 16;
            int acy = chunk_y * 16;
            int acz = chunk_z * 16;
            //create light mask
            for (short x = 0; x < size; x++)
                for (short y = 0; y < size; y++)
                    for (short z = 0; z < size; z++)
                    {
                        LightMask[x, y, z] = world.IsLightTransparent(
                            acx + x, 
                            (short)(acy + y),
                            acz + z);
                    }
            //fill buffer every lighting block
            for (short x = 0; x < size; x++)
                for (short y = 0; y < size; y++)
                    for (short z = 0; z < size; z++)
                    {
                        var power = world.GetBlockLightPower(
                                    acx + x,
                                    (short)(acy + y),
                                    acz + z);
                        if (power > 0)
                            BlockFillAlgoritm(
                                ref buffer, 
                                LightMask, 
                                (byte)x,
                                (byte)y, 
                                (byte)z,
                                power);
                    }

            //var debug1 = LightMask.ToDebugArray();
            //var debug2 = buffer.ToDebugArray();
            return Convert(buffer);
        }

        public byte[] CreateSkyLightData(ILightWorld world, int chunk_x, short chunk_y, int chunk_z)
        {
            throw new NotImplementedException();
        }

        void BlockFillAlgoritm(ref byte[,,] buffer, bool[,,] LightMask, byte x, byte y, byte z, byte power)
        {
            Queue<f4b> queue = new Queue<f4b>();

            buffer[x, y, z] = power;
            queue.Enqueue(new f4b(x, y, z, power));

            while (queue.Count > 0)
            {
                var el = queue.Dequeue();
                if (!el.isValid) continue;
                if (!LightMask[el.x, el.y, el.z]) continue;
                if (buffer[el.x, el.y, el.z] > el.p) continue;

                buffer[el.x, el.y, el.z] = el.p;
                if (el.p == 0) continue;
                byte newp = (byte)(el.p - 1);
                queue.Enqueue(new f4b((byte)(el.x - 1), el.y, el.z, newp));
                queue.Enqueue(new f4b((byte)(el.x + 1), el.y, el.z, newp));
                queue.Enqueue(new f4b(el.x, (byte)(el.y - 1), el.z, newp));
                queue.Enqueue(new f4b(el.x, (byte)(el.y + 1), el.z, newp));
                queue.Enqueue(new f4b(el.x, el.y, (byte)(el.z - 1), newp));
                queue.Enqueue(new f4b(el.x, el.y, (byte)(el.z + 1), newp));
            }
        }
        byte[] Convert(byte[,,] raw)
        {
            byte[] data = new byte[size * size * size / 2];
            int index = 0;
            for (short y = 0; y < size; y++)
                for (short z = 0; z < size; z++)
                    for (short x = 0; x < size; x += 2)
                        data[index++] = (byte)(raw[x, y, z] | (raw[x + 1, y, z] << 4));
            return data;
        }
        /// <summary>
        /// fill algoritm 3 bytes
        /// </summary>
        struct f4b
        {
            public byte x;
            public byte y;
            public byte z;
            public byte p;

            public bool isValid => 
                (x >= 0 && x < 16) &&
                (y >= 0 && y < 16) &&
                (z >= 0 && z < 16);

            public f4b(byte x, byte y, byte z, byte p)
            {
                this.x = x;
                this.y = y;
                this.z = z;
                this.p = p;
            }
        }
    }
}
