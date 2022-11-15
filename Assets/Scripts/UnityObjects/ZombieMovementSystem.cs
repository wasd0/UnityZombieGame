using UnityEngine;
using Zenject;

namespace UnityObjects
{
    public class ZombieMovementSystem : MonoBehaviour
    {
        private Transform _target;

        [SerializeField] private float _speed = 2;
        private IMovementService<Zombie> _movementService;

        [Inject]
        private void Construct(IMovementService<Zombie> movementService, Player player)
        {
            _movementService = movementService;
            _target = player.transform;
        }

        private void FixedUpdate()
        {
            //TODO: Change Test variant
            if (gameObject != null)
                TestZombieMovement(_target.position);
        }

        private void TestZombieMovement(Vector3 targetPosition)
        {
            if (transform.localPosition.x <= targetPosition.x)
                _movementService.MoveInDirectionWithSpeed(Vector3.right, _speed);
            else
                _movementService.MoveInDirectionWithSpeed(Vector3.left, _speed);
            if (transform.localPosition.z <= targetPosition.z)
                _movementService.MoveInDirectionWithSpeed(Vector3.forward, _speed);
            else
                _movementService.MoveInDirectionWithSpeed(Vector3.back, _speed);
        }
    }
}