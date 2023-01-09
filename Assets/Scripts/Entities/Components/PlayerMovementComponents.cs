using Entities.Interfaces;
using MonoBehaviours.Input;
using Services;
using Services.Interfaces;

namespace Entities.Components
{
    public readonly struct PlayerMovementComponents
    {
        public readonly IMovement movement;
        public readonly DeviceInput DeviceInput;

        public PlayerMovementComponents(IMovement movement, DeviceInput deviceInput)
        {
            this.movement = movement;
            DeviceInput = deviceInput;
        }
    }
}