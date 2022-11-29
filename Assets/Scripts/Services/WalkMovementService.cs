using UnityEngine;

namespace Services
{
    public class WalkMovementService : IMovementService
    {
        public void MoveWithSpeed(GameObject gameObject, Vector3 direction, float speed)
        {
            float relativeSpeed = speed * Time.deltaTime;
            gameObject.transform.localPosition += direction * relativeSpeed;
        }
    }
}