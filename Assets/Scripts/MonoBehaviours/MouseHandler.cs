using Services;
using UnityEngine;
using Zenject;

namespace MonoBehaviours
{
    public class MouseHandler : MonoBehaviour
    {
        private MouseService _mouseService;

        [Inject]
        private void Construct(MouseService mouseService)
        {
            _mouseService = mouseService;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            _mouseService.HandleClick();
        }
    }
}