using UnityEngine;
using Zenject;

namespace UnityObjects
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private float _offsetZ;
        [SerializeField] private float _offsetY;
        private Transform _target;

        [Inject]
        private void Construct(Player player)
        {
            _target = player.transform;
        }

        private void Update()
        {
            Follow();
        }

        private void Follow()
        {
            if (_target != null)
            {
                var position = _target.position;
                float newPositionZ = position.z + _offsetZ;
                float newPositionY = position.y + _offsetY;
                transform.position = new Vector3(position.x, newPositionY, newPositionZ);
            }
        }
    }
}