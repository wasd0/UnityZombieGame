using UnityEngine;

namespace Services
{
    public class WalkMovementService : IMovementService
    {
        public void MoveForwardWithSpeed(GameObject gameObject, Vector3 direction, float speed)
        {
            float fixedSpeed = speed * Time.deltaTime;
            gameObject.transform.localPosition += direction * fixedSpeed;
        }
    }
}