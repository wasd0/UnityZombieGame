using System;
using Services.Interfaces;
using UnityEngine.InputSystem;
using Zenject;

namespace Services.Implementations
{
    public class MouseLookInputService : ILookInputService
    {
        public event Action OnClicked;

        public PlayerInput Input { get; private set; }

        [Inject]
        private void Construct(PlayerInput input)
        {
            Input = input;
        }
        
        public float GetHorizontalAxis()
        {
            return Input.Player.MouseLook.ReadValue<float>();
        }
        
        public void HandleClick()
        {
            if (GetClick())
            {
                OnClicked?.Invoke();
            }
        }
        
        private static bool GetClick()
        {
            return Mouse.current.leftButton.isPressed;
        }
    }
}