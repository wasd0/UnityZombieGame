using Entities;
using Services;
using UnityEngine;
using Zenject;

namespace MonoBehaviours
{
    public class ZombieMovementSystem : MonoBehaviour
    {
        [SerializeField] private float _speed = 3;
        [SerializeField] private float _rotationSpeed = 2;
        [SerializeField] private float _minDistanceToPlayer = 20;

        private Player _player;
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

        private void Update()
        {
            if (TryFindPlayer())
            {
                MoveToPlayer();
            }
        }

        private void MoveToPlayer()
        {
            float relativeSpeed = _speed * Time.deltaTime;
            
            _zombieLook.LookAtPositionWithSpeed(transform, _player.transform.position, _rotationSpeed);
            transform.position += transform.forward * relativeSpeed;
        }

        private bool TryFindPlayer()
        {
            return _player != null && DistanceToPlayer <= _minDistanceToPlayer;
        }
    }
}