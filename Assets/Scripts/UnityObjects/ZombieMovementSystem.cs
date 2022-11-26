using Services;
using UnityEngine;
using Zenject;

namespace UnityObjects
{
    public class ZombieMovementSystem : MonoBehaviour
    {
        [SerializeField] private float _speed = 3;
        [SerializeField] private float _rotationSpeed = 2;
        [SerializeField] private float _minDistanceToPlayer = 20;

        private Player _player;
        private IMovementService _movementService;
        private readonly ZombieLook _zombieLook = new ZombieLook();

        private float DistanceToPlayer
        {
            get
            {
                Vector3 heading = transform.position - _player.transform.position;
                return heading.magnitude;
            }
        }

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }

        private void FixedUpdate()
        {
            if (_player != null && DistanceToPlayer <= _minDistanceToPlayer)
            {
                _zombieLook.LookAtPositionWithSpeed(transform, _player.transform.position, _rotationSpeed);
                _movementService.MoveForwardWithSpeed(gameObject, transform.forward, _speed);
            }
        }

        public void SetMovementService(IMovementService movementService)
        {
            _movementService = movementService;
        }
    }
}