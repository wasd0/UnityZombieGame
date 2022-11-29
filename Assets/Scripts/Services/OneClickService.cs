using System;
using UnityEngine.InputSystem;

namespace Services
{
    public abstract class OneClickService
    {
        public event Action OnClicked;
        
        public void HandleClick()
        {
            if (TryGetClick())
            {
                OnClicked?.Invoke();
            }
        }

        private bool TryGetClick()
        {
            return Mouse.current.leftButton.isPressed;
        }

        public abstract float GetHorizontalAxis();
    }
}