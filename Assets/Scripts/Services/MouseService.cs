using UnityEngine.InputSystem;

namespace Services
{
    public class MouseService : OneClickService
    {
        public override float GetHorizontalAxis()
        {
            return Mouse.current.position.ReadValue().x;
        }
    }
}