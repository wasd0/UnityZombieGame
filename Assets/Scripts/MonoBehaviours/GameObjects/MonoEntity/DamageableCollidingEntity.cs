using Entities.Components;
using Entities.Interfaces;
using UnityEngine;

namespace MonoBehaviours.GameObjects.MonoEntity
{
    public class DamageableCollidingEntity : MonoBehaviour, IMonoDamageable, ICollidingEntity
    {
        [Header("Health")]
        [SerializeField] private float _healthCurrent;
        [SerializeField] private float _healthMax;

        private Health _health;
        
        public Health Health => _health;

        private void Awake()
        {
            _health = new Health(_healthCurrent, _healthMax);
        }

        public void HandleCollision(OnEntityCollided onEntityCollided)
        {
            onEntityCollided?.Invoke(ref _health);
        }
    }
}