using Entities.Components;
using MonoBehaviours.Input;
using UnityEngine;

namespace MonoBehaviours.GameObjects.Entity.Player
{
    public class PlayerMovement : EntityMovement
    {
        [SerializeField] private float _speed;
        [SerializeField] private CharacterController _characterController;
        //TODO: Adapt to smartphone
        private DeviceInput _input;
        private float _horizontalAxis;
        private float _verticalAxis;

        private PlayerMovementComponents _movementComponents;

        protected override CharacterController CharacterController => _characterController;

        private void Awake()
        {
            _input = GetComponent<DeviceInput>();
        }

        private void Update()
        {
            ReadAxis();
            Move();
        }

        private void ReadAxis()
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