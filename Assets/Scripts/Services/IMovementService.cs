using UnityEngine;

namespace Services
{
    public interface IMovementService
    {
        public void MoveGameObjectInDirectionWithSpeed(GameObject gameObject, Vector3 direction, float speed);
    }
}