using System.Runtime.CompilerServices;

public static class MinecraftCoordinatesSystem
{

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int PosToChunk1D(float x) => x < 0 ? (int)(x - 1) >> 4 : (int)x >> 4;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GetChunkSectionFromCoords(
        int x, int y, int z,
        out int csx, out int csy, out int csz)
    {
        csx = PosToChunk1D(x);
        csy = PosToChunk1D(y);
        csz = PosToChunk1D(z);
    }
    public static v2i GetChunkFromCoords(v3f position)
    {
        return new v2i(PosToChunk1D(position.x), PosToChunk1D(position.z));
    }
}
