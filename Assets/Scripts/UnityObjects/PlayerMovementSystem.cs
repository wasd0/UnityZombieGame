using Entities.Components;
using Services;
using UnityEngine;

namespace UnityObjects
{
    [RequireComponent(typeof(DeviceInput))]
    public class PlayerMovementSystem : MonoBehaviour
    {
        [SerializeField] private float _speed = 5;
        private PlayerMovementComponents _movementComponents;
        private float _horizontalAxis;
        private float _verticalAxis;

        private void Awake()
        {
            DeviceInput deviceInput = GetComponent<DeviceInput>();
            _movementComponents = new PlayerMovementComponents(new WalkMovementService(), deviceInput);
        }

        private void FixedUpdate()
        {
            MoveHorizontal();
            MoveVertical();
        }

        private void Update()
        {
            _horizontalAxis = _movementComponents.DeviceInput.GetHorizontalAxis();
            _verticalAxis = _movementComponents.DeviceInput.GetVerticalAxis();
        }

        private void MoveVertical()
        {
            IMovementService _movement = _movementComponents.MovementService;

            if (_verticalAxis > 0)
                _movement.MoveForwardWithSpeed(gameObject, transform.forward, _speed);
            else if (_verticalAxis < 0)
                _movement.MoveForwardWithSpeed(gameObject, -transform.forward, _speed);
        }

        private void MoveHorizontal()
        {
            IMovementService _movement = _movementComponents.MovementService;
            
            
            if (_horizontalAxis > 0)
                _movement.MoveForwardWithSpeed(gameObject, transform.right, _speed);
            else if (_horizontalAxis < 0)
                _movement.MoveForwardWithSpeed(gameObject, -transform.right, _speed);
        }
    }
}