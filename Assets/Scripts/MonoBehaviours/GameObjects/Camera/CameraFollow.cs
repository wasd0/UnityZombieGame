using Entities;
using Entities.Neutral;
using UnityEngine;
using Zenject;

namespace MonoBehaviours.GameObjects.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        private Transform _playerTransform;

        [Inject]
        private void Construct(Player player)
        {
            _playerTransform = player.transform;
        }

        private void LateUpdate()
        {
            Follow();
        }

        private void Follow()
        {
            if (_playerTransform != null)
            {
                float angle = _playerTransform.eulerAngles.y;
                Quaternion rotation = Quaternion.Euler(0, angle, 0);

                transform.position = _playerTransform.position - rotation * _offset;
                transform.LookAt(_playerTransform);
            }
        }
    }
}