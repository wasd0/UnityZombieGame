using UnityEngine;

namespace Services
{
    public interface IMovementService
    {
        public void MoveForwardWithSpeed(GameObject gameObject, Vector3 direction, float speed);
    }
}