using Services;
using UnityEngine;
using Zenject;

namespace UnityObjects
{
    public class ZombieMovementSystem : MonoBehaviour
    {
        [SerializeField] private float _speed = 3;
        [SerializeField] private float _rotationSpeed = 2;
        [SerializeField] private float _distanceToPlayer = 15;
        [Inject] private Player _player;
        
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

        private void Update()
        {
            if (_player != null && DistanceToPlayer <= _distanceToPlayer)
            {
                _movementService.MoveGameObjectInDirectionWithSpeed(gameObject, transform.forward, _speed);
                _zombieLook.LookAtPositionWithSpeed(transform, _player.transform, _rotationSpeed);
            }
        }

        public void SetMovementService(IMovementService movementService)
        {
            _movementService = movementService;
        }
    }
}