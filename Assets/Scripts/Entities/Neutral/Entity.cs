using System;
using UnityEngine;

namespace Entities.Neutral
{
    public class Entity : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _health;

        public float Health
        {
            get => _health;
            private set
            {
                _health = Mathf.Clamp(value, 0, MaxHealth);
                OnHealthChanged?.Invoke();
                if (_health <= 0)
                    OnDead?.Invoke();
            }
        }

        public float MaxHealth { get; } = 100;

        public event Action OnHealthChanged;
        public event Action<IAttacker> OnGetDamage;
        public event Action OnDead;

        public void ApproveDamage(IAttacker attacker)
        {
            OnGetDamage?.Invoke(attacker);
        }

        private void GotDamage(IAttacker source)
        {
            Health -= source.Damage;
        }

        private void OnEnable()
        {
            OnDead += Die;
            OnGetDamage += GotDamage;
        }

        private void OnDisable()
        {
            OnDead -= Die;
            OnGetDamage -= GotDamage;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}