using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityObjects
{
    public class KeyboardInput : DeviceInput
    {
        private float _directionX;
        private float _directionZ;
            
        public override float GetVerticalAxis()
        {
            return _input.Movement.Keyboard.ReadValue<Vector2>().y;
        }
        
        public override float GetHorizontalAxis()
        {
            return _input.Movement.Keyboard.ReadValue<Vector2>().x;
        }

        public override float GetHorizontalRotation()
        {
            return Mouse.current.position.ReadValue().x;
        }
    }
}