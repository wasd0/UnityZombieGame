using UnityEngine;
using Zenject;

namespace UnityObjects
{
    public class PlayerMovementSystem : MonoBehaviour
    {
        [SerializeField] private float _speed = 5;
        private IMovementService _movementService;
        private Vector3 _moveDirection;
        private PlayerInput _input;
        
        public void SetMovementService(IMovementService movementService)
        {
            _movementService = movementService;
        }

        private void Awake()
        {
            _input = new PlayerInput();
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void FixedUpdate()
        {
            float x = _input.Movement.WASD.ReadValue<Vector2>().x;
            float z = _input.Movement.WASD.ReadValue<Vector2>().y;
            _moveDirection = new Vector3(x, 0, z);

            _movementService.MoveGameObjectInDirectionWithSpeed(gameObject, _moveDirection, _speed);
        }
    }
}

