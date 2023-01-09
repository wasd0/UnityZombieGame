using Entities.Enemy;
using MonoBehaviours.GameObjects.Entity;
using MonoBehaviours.GameObjects.MonoEntity.Player;
using UnityEngine;
using Zenject;

namespace MonoBehaviours.GameObjects.MonoEntity.Zombie
{
    public class MovementToPlayer : MonoBehaviour, IEntityMovement
    {
        [SerializeField] private float _speed = 3;
        [SerializeField] private float _minDistanceToPlayer = 20;
        
        private CharacterController _characterController;
        private PlayerMono _playerMono;
        
        public CharacterController CharacterController => _characterController;

        [Inject]
        private void Construct(PlayerMono playerMono)
        {
            _playerMono = playerMono;
        }

        private void Update()
        {
            if (DistanceCalculator.CompareDistance(_playerMono, transform, _minDistanceToPlayer))
            {
                Move();
            } 
        }

        public void Move()
        {
            var relativeSpeed = _speed * Time.deltaTime;
            CharacterController.Move(transform.forward * relativeSpeed);
        }

        private void OnEnable()
        {
            _characterController = GetComponent<CharacterController>();
        }
    }
}