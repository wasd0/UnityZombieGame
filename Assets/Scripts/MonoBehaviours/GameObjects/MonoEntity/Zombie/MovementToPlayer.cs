using Entities;
using Entities.StaticClasses;
using MonoBehaviours.GameObjects.MonoEntity.Player;
using UnityEngine;
using Zenject;

namespace MonoBehaviours.GameObjects.MonoEntity.Zombie
{
    public class MovementToPlayer : MonoBehaviour
    {
        //TODO: TEST VARIANT
        [SerializeField] private float _speed = 3;
        [SerializeField] private float _minDistanceToPlayer = 20;

        private CharacterController _characterController;
        private Transform _playerTransform;

        [Inject]
        private void Construct(PlayerMovementTest playerMovement)
        {
            _playerTransform = playerMovement.transform;
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            var distance = GetDistanceToPlayer();
            
            if (distance <= _minDistanceToPlayer)
            {
                MovementForward.MoveForward(transform, _characterController, _speed);
            } 
        }
        private float GetDistanceToPlayer()
        {
            var heading = transform.position - _playerTransform.position;
            return heading.magnitude;
        }
    }
}