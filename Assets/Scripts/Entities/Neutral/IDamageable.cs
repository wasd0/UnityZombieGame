using System;
using Entities;

public interface IDamageable
{
    public event Action OnHealthChanged;
    public event Action OnDead;

    public void GetDamage(IAttacker attacker);
}