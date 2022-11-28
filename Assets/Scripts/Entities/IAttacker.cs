using Items.Weapon;

namespace Entities
{
    public interface IAttacker
    {
        public Weapon Weapon { get; }
    }
}