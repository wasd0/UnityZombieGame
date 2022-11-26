namespace Entities.Components.Weapon
{
    public interface IWeapon
    {
        public float Damage { get; }
        public float Range { get; }
        public float DelayInSeconds { get; }
    }
}