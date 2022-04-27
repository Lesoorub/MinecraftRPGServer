﻿public struct PlayerSettings
{
    public byte ViewDistance;
    public const int KeepAliveDelay = 20000;//Default for minecraft
    public const int MaxTimeout = 30000;//Default for minecraft
    public const float ItemPickUpRadius = 1.4f;

    public void UpdateBy(Packets.Play.ClientSettings settings)
    {
        ViewDistance = settings.ViewDistance;
    }
}