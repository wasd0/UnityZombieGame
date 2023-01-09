using Entities.Components;
using MonoBehaviours.GameObjects.Entity;
using MonoBehaviours.Input;
using UnityEngine;
using Zenject;

namespace MonoBehaviours.GameObjects.MonoEntity.Player
{
    public class PlayerMovementTest : MonoBehaviour, IEntityMovement
    {
        [SerializeField] private float _speed;

        private CharacterController _characterController;

        //TODO: Add smartphone support
        private DeviceInput _input;
        private float _horizontalAxis;
        private float _verticalAxis;

        private PlayerMovementComponents _movementComponents;

        public CharacterController CharacterController => _characterController;

        [Inject]
        private void Construct(PlayerInput playerInput)
        {
            _input = new KeyboardInput(playerInput);
        }

        private void Update()
        {
            GetMoveDirection();
            Move();
        }

        private void GetMoveDirection()
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

        private void OnEnable()
        {
            _characterController = GetComponent<CharacterController>();
            _input.Input.Enable();
        }

        private void OnDisable()
        {
            _input.Input.Disable();
        }
    }
}