using System;

public class LoadedEntity<T> where T : Entity
{
    public v2f PreviousRotation;
    public v3f PreviousPosition;
    public long PreviousMetadataTime;
    public long PreviousPositionSyncTime;
    public T entity;

    public LoadedEntity(T entity)
    {
        this.entity = entity;
        PreviousPosition = entity.Position.Clone();
        PreviousRotation = new v2f(entity.Rotation.x, entity.Rotation.y);
        var now = Time.GetTime();
        PreviousMetadataTime = now;
        PreviousPositionSyncTime = now;
    }
}