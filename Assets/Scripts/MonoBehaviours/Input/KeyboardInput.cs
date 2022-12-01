using UnityEngine;

namespace MonoBehaviours.Input
{
    public class KeyboardInput : DeviceInput
    {
        private float _directionX;
        private float _directionZ;

        public override float GetVerticalAxis()
        {
            return _input.Player.Keyboard.ReadValue<Vector2>().y;
        }
        
        public override float GetHorizontalAxis()
        {
            return _input.Player.Keyboard.ReadValue<Vector2>().x;
        }
    }
}