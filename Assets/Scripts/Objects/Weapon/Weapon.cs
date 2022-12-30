using Objects.Interfaces;

namespace Objects.Weapon
{
    public class Weapon : IDamageSource
    {
        public IDamage Damage { get; }
    }
}