using UnityEngine;

namespace Entities.Interfaces
{
    public interface IMovement
    {
        public void MoveWithSpeed(GameObject gameObject, Vector3 direction, float speed);
    }
}