using System;

namespace Services.Interfaces
{
    public interface ILookInputService
    {
        public event Action OnClicked;
        
        public PlayerInput Input { get; }

        public void HandleClick();

        public float GetHorizontalAxis();
    }
}