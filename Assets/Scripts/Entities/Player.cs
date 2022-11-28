using Entities.Neutral;
using Items.Weapon;

namespace Entities
{
    public class Player :  Entity, IAttacker
    {
        public Weapon Weapon { get; } = new Pistol(15, 15, 0.5f);
    }
}