using UnityEngine;

namespace Services
{
    public class ZombieLook
    {
        public void LookAtPositionWithSpeed(Transform transform, Vector3 target, float rotationSpeed)
        {
            Vector3 relativePos = target - transform.localPosition;
            float relativeSpeed = rotationSpeed * Time.deltaTime;
            var newRotation =
                Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(relativePos), relativeSpeed);
            transform.rotation = new Quaternion(0, newRotation.y, 0, newRotation.w);
        }
    }
}