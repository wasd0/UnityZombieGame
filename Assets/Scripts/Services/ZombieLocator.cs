using Entities;
using Entities.Neutral;
using UnityEngine;

namespace Services
{
    public static class ZombieLocator
    {
        public static bool CompareDistance(Player player, Transform zombieTransform, float minDistance)
        {
            return player != null && DistanceToPlayer(player, zombieTransform) <= minDistance;
        }

        private static float DistanceToPlayer(Player player, Transform zombieTransform)
        {
            Vector3 heading = zombieTransform.position - player.transform.position;
            return heading.magnitude;
        }
    }
}