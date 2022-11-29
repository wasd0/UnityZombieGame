using UnityEngine;
using Zenject;

namespace UnityObjects
{
    public abstract  class DeviceInput : MonoBehaviour
    {
        protected PlayerInput _input;

        public abstract float GetVerticalAxis();
        public abstract float GetHorizontalAxis();

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
    }
}