using Entities.Components;

namespace Entities.Interfaces
{
    public delegate void OnEntityCollided(ref Health health);
    
    public interface ICollidingEntity
    {
        public void HandleCollision(OnEntityCollided onEntityCollided);
    }
}