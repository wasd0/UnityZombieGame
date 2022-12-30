using Entities.Components;
using Entities.Interfaces;
using UnityEngine;

namespace Entities.Neutral
{
    public class EntityComponents : MonoBehaviour, IDamageable, ICollidingEntity
    {
        [SerializeField] private float _healthValueCurrent;
        [SerializeField] private float _healthMax;

        private Health _health;
        
        public Health Health => _health;

        private void Awake()
        {
            _health = new Health(_healthValueCurrent, _healthMax);
        }

        public void HandleCollision(OnEntityCollided onEntityCollided)
        {
            onEntityCollided?.Invoke(ref _health);
        }
    }
}