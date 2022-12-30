using UnityEngine;

namespace MonoBehaviours.GameObjects.Colliding
{
    public interface ICollidingItem
    {
        public void Collide(Collider other);
    }
}