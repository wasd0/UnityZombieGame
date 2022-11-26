using Entities.Components.Weapon;
using Entities.Neutral;

namespace Entities
{
    public class Player :  Entity, IAttacker
    {
        public IWeapon Weapon { get; } = new Pistol(15, 15, 0.5f);
    }
}