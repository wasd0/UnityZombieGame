using Services;
using UnityEngine;
using Zenject;

namespace MonoBehaviours
{
    public class PlayerRotateWithMouse : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;
        private MouseService _mouseService;
        private float _rotateValue;

        [Inject]
        private void Construct(MouseService mouseService)
        {
            _mouseService = mouseService;
        }

        private void FixedUpdate()
        {
            _rotateValue = _mouseService.GetHorizontalAxis();
            RotateToMouse();
        }

        private void RotateToMouse()
        {
            var horizontalRotation = _rotateValue * _rotateSpeed * Time.fixedDeltaTime;
            
            transform.Rotate(Vector3.up * horizontalRotation);
        }
    }
}