using Entities.Interfaces;
using Items.Weapon;
using UnityEngine;

namespace Entities.Neutral
{
    public class Player :  Entity, IAttacker
    {
        [SerializeField] private Gun _test;

        public IWeapon Weapon => _test;
        public float Damage => Weapon.Preset.Damage;
    }
}