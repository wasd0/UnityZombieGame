using Services;
using UnityEngine;
using Zenject;

namespace UnityObjects
{
    public class MouseHandler : MonoBehaviour
    {
        private MouseService _mouseService;

        [Inject]
        private void Construct(MouseService mouseService)
        {
            _mouseService = mouseService;
        }

        private void Update()
        {
            _mouseService.HandleClick();
        }
    }
}