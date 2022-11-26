using UnityEngine;

namespace Factories.Components
{
    public readonly struct ZombieSpawnPosition
    {
        public readonly Transform Point;

        public ZombieSpawnPosition(Transform point)
        {
            Point = point;
        }
    }
}