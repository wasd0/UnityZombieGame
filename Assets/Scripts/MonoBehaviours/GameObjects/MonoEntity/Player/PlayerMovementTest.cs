using MonoBehaviours.Input;
using UnityEngine;
using Zenject;

namespace MonoBehaviours.GameObjects.MonoEntity.Player
{
    public class PlayerMovementTest : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private CharacterController _characterController;

        //TODO: TEST VARIANT
        private DeviceInput _input;
        private float _horizontalAxis;
        private float _verticalAxis;

        [Inject]
        private void Construct(PlayerInput playerInput)
        {
            _input = new KeyboardInput(playerInput);
        }

        private void Update()
        {
            GetMoveDirection();
            Move(transform, _speed);
        }

        private void GetMoveDirection()
        {
            _horizontalAxis = _input.GetHorizontalAxis();
            _verticalAxis = _input.GetVerticalAxis();
        }

        private void Move(Transform thisTransform, float speed)
        {
            var relativeSpeed = speed * Time.deltaTime;
            var moveDirection = thisTransform.forward * _verticalAxis + transform.right * _horizontalAxis;

            _characterController.Move(moveDirection * relativeSpeed);
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