using UnityEngine;

public readonly struct PlayerSpawnPosition
{
    public readonly Transform PointTransform;

    public PlayerSpawnPosition(Transform pointTransform)
    {
        PointTransform = pointTransform;
    }
}