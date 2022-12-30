using Entities.Components;
using MonoBehaviours.Input;
using UnityEngine;

namespace MonoBehaviours.GameObjects.Entity.Player
{
    public class PlayerMovement : MonoBehaviour, IEntityMovement
    {
        [SerializeField] private float _speed;
        [SerializeField] private CharacterController _characterController;
        //TODO: Adapt to smartphone
        private DeviceInput _input;
        private float _horizontalAxis;
        private float _verticalAxis;

        private PlayerMovementComponents _movementComponents;

        public CharacterController CharacterController => _characterController;

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

        public void Move()
        {
            var relativeSpeed = _speed * Time.deltaTime;
            var moveDirection = transform.forward * _verticalAxis + transform.right * _horizontalAxis;
            
            CharacterController.Move(moveDirection * relativeSpeed);
        }
    }
}