using System;
using UnityEngine.InputSystem;

namespace Services
{
    public class MouseService
    {
        public event Action OnMousePressed;

        public float GetHorizontalAxis()
        {
            return Mouse.current.position.ReadValue().x;
        }

        public void HandleClick()
        {
            if (TryGetMouseClick())
            {
                OnMousePressed?.Invoke();
            }
        }

        private bool TryGetMouseClick()
        {
            return Mouse.current.leftButton.isPressed;
        }
    }
}