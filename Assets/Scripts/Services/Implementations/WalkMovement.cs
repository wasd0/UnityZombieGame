using Entities.Interfaces;
using Services.Interfaces;
using UnityEngine;

namespace Services.Implementations
{
    public class WalkMovement : IMovement
    {
        public void MoveWithSpeed(GameObject gameObject, Vector3 direction, float speed)
        {
            float relativeSpeed = speed * Time.deltaTime;
            gameObject.transform.localPosition += direction * relativeSpeed;
        }
    }
}