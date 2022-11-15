using UnityEngine;
using Zenject;

namespace UnityObjects
{
    public class ZombieMovementSystem : MonoBehaviour
    {
        [SerializeField] private float _speed = 2;
        [Inject] private Player _player;

        private IMovementService _movementService;

        public void SetMovementService(IMovementService movementService)
        {
            _movementService = movementService;
        }

        private void LateUpdate()
        {
            //TODO: Change Test variant
            if (IsPlayerALive())
                TestZombieMovement(_player.transform.position);
        }

        private void TestZombieMovement(Vector3 targetPosition)
        {
            if (transform.localPosition.x <= targetPosition.x)
                _movementService.MoveGameObjectInDirectionWithSpeed(gameObject, Vector3.right, _speed);
            else
                _movementService.MoveGameObjectInDirectionWithSpeed(gameObject, Vector3.left, _speed);
            if (transform.localPosition.z <= targetPosition.z)
                _movementService.MoveGameObjectInDirectionWithSpeed(gameObject, Vector3.forward, _speed);
            else
                _movementService.MoveGameObjectInDirectionWithSpeed(gameObject, Vector3.back, _speed);
        }

        private bool IsPlayerALive()
        {
            if (_player == null)
            {
                enabled = false;
                return false;
            }
            return true;
        }
    }
}