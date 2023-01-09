using UnityEngine;

namespace Entities.Interfaces
{
    public interface IMovementStrategy
    {
        public void MoveWithSpeed(GameObject gameObject, Vector3 direction, float speed);
    }
}