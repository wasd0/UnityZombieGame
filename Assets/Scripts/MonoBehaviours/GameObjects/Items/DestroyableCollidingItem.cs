using System;
using Objects.Interfaces;
using UnityEngine;

namespace MonoBehaviours.GameObjects.Items
{
    public class DestroyableCollidingItem : MonoBehaviour, ICollidingItem
    {
        public event Action OnCollisionDetected;

        public void Collide()
        {
            OnCollisionDetected?.Invoke();
            Destroy(gameObject);
        }
    }
}