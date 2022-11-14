using UnityEngine;
using Zenject;

namespace UnityObjects
{
    public class ZombieMovementSystem : MonoBehaviour
    {
        #region Test

        private Transform _target;

        #endregion

        [SerializeField] private float _speed;
        private IMovementService<Zombie> _movementService;

        [Inject]
        private void Construct(IMovementService<Zombie> movementService, Player player)
        {
            _movementService = movementService;
            _target = player.transform;
        }

        private void Update()
        {
            //TODO: Change Test variant
            TestZombieMovement(_target.position);
        }

        private void TestZombieMovement(Vector3 targetPosition)
        {
            if (transform.position.x <= targetPosition.x)
                _movementService.MoveInDirectionWithSpeed(Vector3.right, _speed);
            else
                _movementService.MoveInDirectionWithSpeed(Vector3.left, _speed);
            if (transform.position.z <= targetPosition.z)
                _movementService.MoveInDirectionWithSpeed(Vector3.forward, _speed);
            else
                _movementService.MoveInDirectionWithSpeed(Vector3.back, _speed);
        }
    }
}