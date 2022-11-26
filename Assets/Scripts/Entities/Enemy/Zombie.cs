using System;
using UnityEngine;

namespace Entities.Enemy
{
    public class Zombie : Entity, IDamageable
    {
        [SerializeField] private float _health;

        private float Health
        {
            get => _health;
            set
            {
                _health = Mathf.Clamp(value, 0, 100);
                OnHealthChanged?.Invoke();
                if (_health <= 0)
                    OnDead?.Invoke();
            }
        }

        public event Action OnHealthChanged;
        public event Action OnDead;

        public void GetDamage(IAttacker attacker)
        {
            Health -= attacker.Weapon.Damage;
        }

        private void OnEnable()
        {
            OnDead += Dead;
        }

        private void OnDisable()
        {
            OnDead -= Dead;
        }

        private void Dead()
        {
            Destroy(gameObject);
        }
    }
}