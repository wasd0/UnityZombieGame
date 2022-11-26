using System;
using Entities;
using Entities.Components.Weapon;
using UnityEngine;

//TODO: Make Entity as damageable
public class Player :  Entity, IDamageable, IAttacker
{
    [SerializeField] private float _health;

    public IWeapon Weapon { get; } = new Pistol(15, 15, 0.5f);

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
        Health -= Weapon.Damage;
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