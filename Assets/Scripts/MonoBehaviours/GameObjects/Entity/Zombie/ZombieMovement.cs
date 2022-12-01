using Services;
using UnityEngine;
using Zenject;

namespace MonoBehaviours.GameObjects.Entity.Zombie
{
    public class ZombieMovement : EntityMovement
    {
        [SerializeField] private float _speed = 3;
        [SerializeField] private float _minDistanceToPlayer = 20;
        [SerializeField] private CharacterController _characterController;

        protected override CharacterController CharacterController => _characterController;
        
        private Entities.Neutral.Player _player;


        [Inject]
        private void Construct(Entities.Neutral.Player player)
        {
            _player = player;
        }

        private void Update()
        {
            if (ZombieLocator.CompareDistance(_player, transform, _minDistanceToPlayer))
            {
                Move();
            } 
        }

        protected override void Move()
        {
            var relativeSpeed = _speed * Time.deltaTime;
            CharacterController.Move(transform.forward * relativeSpeed);
        }
    }
}