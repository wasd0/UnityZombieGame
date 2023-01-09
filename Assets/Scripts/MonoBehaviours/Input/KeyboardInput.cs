using UnityEngine;

namespace MonoBehaviours.Input
{
    public class KeyboardInput : DeviceInput
    {
        private float _directionX;
        private float _directionZ;

        public KeyboardInput(PlayerInput input) : base(input) {}

        public override float GetVerticalAxis()
        {
            return Input.Player.Keyboard.ReadValue<Vector2>().y;
        }


        public override float GetHorizontalAxis()
        {
            return Input.Player.Keyboard.ReadValue<Vector2>().x;
        }
    }
}