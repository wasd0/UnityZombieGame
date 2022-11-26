using Services;
using UnityObjects;

namespace Entities.Components
{
    public readonly struct PlayerMovementComponents
    {
        public readonly IMovementService MovementService;
        public readonly IDeviceInput DeviceInput;

        public PlayerMovementComponents(IMovementService movementService, IDeviceInput deviceInput)
        {
            MovementService = movementService;
            DeviceInput = deviceInput;
        }
    }
}