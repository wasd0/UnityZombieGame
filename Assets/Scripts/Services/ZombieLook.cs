using UnityEngine;

public class ZombieLook
{
    public void LookAtPositionWithSpeed(Transform transform, Transform target, float rotationSpeed)
    {
        Vector3 relativePos = target.position - transform.localPosition;
        float relationRotationSpeed = rotationSpeed * Time.deltaTime;
        var newRotation =
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(relativePos), relationRotationSpeed);
        transform.rotation = new Quaternion(0, newRotation.y, 0, newRotation.w);
    }
}