using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityObjects
{
    public class KeyboardInput : MonoBehaviour, IDeviceInput
    {
        private float _directionX;
        private float _directionZ;
        private PlayerInput _input;

        private void Awake()
        {
            _input = new PlayerInput();
        }

        public float GetVerticalAxis()
        {
            return _input.Movement.Keyboard.ReadValue<Vector2>().y;
        }
        
        public float GetHorizontalAxis()
        {
            return _input.Movement.Keyboard.ReadValue<Vector2>().x;
        }

        public float GetHorizontalRotation()
        {
            return Mouse.current.position.ReadValue().x;
        }
        
        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }
    }
}