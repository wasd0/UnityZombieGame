namespace Entities.Components.Weapon
{
    public readonly struct Pistol : IWeapon
    {
        public float Damage { get; }
        public float Range { get; }
        public float DelayInSeconds { get; }

        public Pistol(float damage, float range, float shootDelay)
        {
            Damage = damage;
            Range = range;
            DelayInSeconds = shootDelay;
        }
    }
}