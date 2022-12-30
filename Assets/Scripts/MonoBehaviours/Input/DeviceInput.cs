using UnityEngine;
using Zenject;

namespace MonoBehaviours.Input
{
    public abstract  class DeviceInput : MonoBehaviour
    {
        protected PlayerInput _input;

        [Inject]
        private void Construct(PlayerInput input)
        {
            _input = input;
        }
        
        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        public abstract float GetVerticalAxis();
        public abstract float GetHorizontalAxis();
    }
}