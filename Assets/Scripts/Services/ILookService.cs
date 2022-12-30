using System;

namespace Services
{
    public interface ILookService
    {
        public event Action OnClicked;
        
        public PlayerInput Input { get; }

        public void HandleClick();

        public float GetHorizontalAxis();
    }
}