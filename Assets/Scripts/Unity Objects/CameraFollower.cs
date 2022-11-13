using UnityEngine;
using Zenject;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private float _offsetZ;
    [SerializeField] private float _offsetY;
    private Transform _target;

    [Inject]
    private void Construct(Player targetOfFollow)
    {
        _target = targetOfFollow.transform;
    }

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        if (_target != null)
        {
            var position = _target.transform.position;
            float newPositionZ = position.z + _offsetZ;
            float newPositionY = position.y + _offsetY;
            transform.position = new Vector3(position.x, newPositionY, newPositionZ);
        }
    }
}