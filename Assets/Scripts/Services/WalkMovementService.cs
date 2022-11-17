using UnityEngine;

namespace Services
{
    public class WalkMovementService : IMovementService
    {
        public void MoveGameObjectInDirectionWithSpeed(GameObject gameObject, Vector3 direction, float speed)
        {
            float fixedSpeed = speed * Time.deltaTime;
            gameObject.transform.localPosition += direction * fixedSpeed;
        }
    }
}