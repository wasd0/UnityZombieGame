using System.Collections;
using UnityEngine;

namespace Items.Weapon
{
    public class Weapon
    {
        public float Damage { get; }
        public float Range { get; }
        public float CooldownAttack { get; }

        private bool _isReaload;

        protected Weapon(float damage, float range, float cooldownAttack)
        {
            Damage = damage;
            Range = range;
            CooldownAttack = cooldownAttack;
        }

        //TODO: Replace to Gun class
        private IEnumerator OnAmmoIsEmpty()
        {
            if (!_isReaload)
            {
                yield break;
            }
            yield return new WaitForSeconds(CooldownAttack);
            _isReaload = false;
        }
    }
}