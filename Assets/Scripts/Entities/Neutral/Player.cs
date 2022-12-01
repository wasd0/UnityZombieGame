using Entities.Interfaces;
using Items.Weapon;

namespace Entities.Neutral
{
    public class Player :  Entity, IAttacker
    {
        public Weapon Weapon { get; } = new Pistol(15, 15, 0.5f);
        public float Damage => Weapon.Damage;
    }
}