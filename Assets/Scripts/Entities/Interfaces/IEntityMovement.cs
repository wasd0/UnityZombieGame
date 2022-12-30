using UnityEngine;

namespace MonoBehaviours.GameObjects.Entity
{
    public interface IEntityMovement
    {
        public CharacterController CharacterController { get; }
        
        public void Move();
    }
}