using Entities.Interfaces;
using UnityEngine;

namespace Services.Implementations
{
    public class WalkMovementStrategy : IMovementStrategy
    {
        public void MoveWithSpeed(GameObject gameObject, Vector3 direction, float speed)
        {
            var relativeSpeed = speed * Time.deltaTime;
            gameObject.transform.localPosition += direction * relativeSpeed;
        }
    }
}