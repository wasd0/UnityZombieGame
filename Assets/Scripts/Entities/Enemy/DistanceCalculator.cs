using MonoBehaviours.GameObjects.MonoEntity.Player;
using UnityEngine;

namespace Entities.Enemy
{
    public class DistanceCalculator
    {
        public static bool CompareDistance(PlayerMono playerMono, Transform zombieTransform, float minDistance)
        {
            return playerMono != null && DistanceToPlayer(playerMono, zombieTransform) <= minDistance;
        }

        private static float DistanceToPlayer(PlayerMono playerMono, Transform zombieTransform)
        {
            Vector3 heading = zombieTransform.position - playerMono.transform.position;
            return heading.magnitude;
        }
    }
}