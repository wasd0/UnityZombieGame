using Services;
using UnityEngine;
using Zenject;

namespace MonoBehaviours
{
    public class PlayerRotate : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;
        private float _mousePositionX;
        private OneClickService _clickService;

        [Inject]
        private void Construct(MouseService mouseService)
        {
            _clickService = mouseService;
        }
        
        private void FixedUpdate()
        {
            _mousePositionX = _clickService.GetHorizontalAxis();

            RotateToMouse();
        }

        private void RotateToMouse()
        {
            float relativeSpeed = _rotateSpeed * Time.deltaTime;
            Quaternion relativeRotate = Quaternion.Euler(0, _mousePositionX, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, relativeRotate, relativeSpeed);
        }
    }
}