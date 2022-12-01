using System;
using ScriptableObjects;

namespace Items.Weapon
{
    public interface IWeapon
    {
        public WeaponPreset Preset { get; }
        
        public event Action OnAttack;

        public void Attack();
    }
}