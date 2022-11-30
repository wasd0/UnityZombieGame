using Entities.Components;
using UnityEngine;

namespace MonoBehaviours
{
    public class PlayerMovementSystem : EntityMovementSystem
    {
        [SerializeField] private float _speed;

        private DeviceInput _input;
        private float _horizontalAxis;
        private float _verticalAxis;
        
        private PlayerMovementComponents _movementComponents;
        
        protected override CharacterController CharacterController { get; set; }


        private void Awake()
        {
            _input = GetComponent<DeviceInput>();
            CharacterController = GetComponent<CharacterController>();
        }

        protected override void ReadAxis()
        {
            _horizontalAxis = _input.GetHorizontalAxis();
            _verticalAxis = _input.GetVerticalAxis();
        }

        protected override void Move()
        {
            float relativeSpeed = _speed * Time.deltaTime;
            Vector3 moveDirection = transform.forward * _verticalAxis + transform.right * _horizontalAxis;

            CharacterController.Move(moveDirection * relativeSpeed);
        }
    }
}