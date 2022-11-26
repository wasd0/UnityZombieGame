using Entities.Components.Weapon;

namespace Entities
{
    public interface IAttacker
    {
        public IWeapon Weapon { get; }
    }
}