using MonoBehaviours;
using MonoBehaviours.Input;
using Services;

namespace Entities.Components
{
    public readonly struct PlayerMovementComponents
    {
        public readonly IMovementService MovementService;
        public readonly DeviceInput DeviceInput;

        public PlayerMovementComponents(IMovementService movementService, DeviceInput deviceInput)
        {
            MovementService = movementService;
            DeviceInput = deviceInput;
        }
    }
}