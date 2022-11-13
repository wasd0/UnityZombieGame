using UnityEngine;

public readonly struct SpawnPosition
{
    public readonly Transform Point;

    public enum Markers
    {
        Player,
        Enemy
    }

    public SpawnPosition(Transform point)
    {
        Point = point;
    }
}