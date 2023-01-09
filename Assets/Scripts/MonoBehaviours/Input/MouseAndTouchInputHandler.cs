using Services.Interfaces;
using UnityEngine;
using Zenject;

namespace MonoBehaviours.Input
{
    public class MouseAndTouchInputHandler : MonoBehaviour
    {
        private ILookInputService _lookInputService;
        
        [Inject]
        private void Construct(ILookInputService lookInputService)
        {
            _lookInputService = lookInputService;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            _lookInputService?.HandleClick();
        }
    }
}