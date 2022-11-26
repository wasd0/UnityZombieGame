using Entities.Components;
using Services;
using UnityEngine;

namespace UnityObjects
{
    [RequireComponent(typeof(IDeviceInput))]
    public class PlayerMovementSystem : MonoBehaviour
    {
        [SerializeField] private float _speed = 5;
        private Vector3 _moveDirection;
        private PlayerMovementComponents _movementComponents;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            IDeviceInput deviceInput = GetComponent<IDeviceInput>();
            _movementComponents = new PlayerMovementComponents(new WalkMovementService(), deviceInput);
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Update()
        {
            float horizontalAxis = _movementComponents.DeviceInput.GetHorizontalAxis();
            float verticalAxis = _movementComponents.DeviceInput.GetVerticalAxis();
            
            _moveDirection = new Vector3(horizontalAxis, 0, verticalAxis);
        }

        private void Move()
        {
            _movementComponents.MovementService.MoveForwardWithSpeed(gameObject, _moveDirection, _speed);
        }
    }
}

