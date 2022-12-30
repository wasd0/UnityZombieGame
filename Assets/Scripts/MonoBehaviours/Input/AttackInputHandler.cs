using Services;
using UnityEngine;
using Zenject;

namespace MonoBehaviours.Input
{
    public class AttackInputHandler : MonoBehaviour
    {
        private ILookService _lookService;
        
        [Inject]
        private void Construct(ILookService lookService)
        {
            _lookService = lookService;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            _lookService?.HandleClick();
        }
    }
}