using Objects.Interfaces;

namespace Objects.Damage
{
    public readonly struct PhysicalDamage : IDamage
    {
        public float Value { get; }
        
        public PhysicalDamage(float value) => Value = value;
    }
}