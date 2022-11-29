using UnityEngine;

namespace Services
{
    public interface IMovementService
    {
        public void MoveWithSpeed(GameObject gameObject, Vector3 direction, float speed);
    }
}