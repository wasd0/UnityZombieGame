using UnityEngine;

public readonly struct ZombieSpawnPosition
{
    public readonly Transform Point;

    public ZombieSpawnPosition(Transform point)
    {
        Point = point;
    }
}