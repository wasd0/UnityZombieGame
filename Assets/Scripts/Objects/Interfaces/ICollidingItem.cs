using System;

namespace Objects.Interfaces
{
    public interface ICollidingItem
    {
        public event Action OnCollisionDetected;
        
        public void Collide();
    }
}