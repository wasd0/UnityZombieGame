using System;
using UnityEngine;

namespace Entities.Neutral
{
    public class Entity : MonoBehaviour, IDamageable
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
            Debug.Log($"{name}: {Health}");
        }

        private void OnEnable()
        {
            OnDead += Die;
        }

        private void OnDisable()
        {
            OnDead -= Die;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}