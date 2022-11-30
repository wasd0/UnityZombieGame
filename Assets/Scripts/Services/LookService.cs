using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Services
{
    public abstract class LookService
    {
        public event Action OnClicked;
        
        protected PlayerInput Input { get; private set; }

        [Inject]
        private void Construct(PlayerInput input)
        {
            Input = input;
        }
        
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