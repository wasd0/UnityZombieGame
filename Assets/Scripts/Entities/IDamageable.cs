using System;

namespace Entities
{
    public interface IDamageable
    {
        public event Action OnHealthChanged;
        public event Action<IAttacker> OnGetDamage;
        public event Action OnDead;

        public void ApproveDamage(IAttacker attacker);
    }
}