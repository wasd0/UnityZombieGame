using Entities.Interfaces;

namespace Objects.Interfaces
{
    public interface IGun : IDamageSource
    {
        public void Shoot(IDamageable target);
    }
}