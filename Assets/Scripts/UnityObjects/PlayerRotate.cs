using UnityEngine;

namespace UnityObjects
{
    [RequireComponent(typeof(KeyboardInput))]
    public class PlayerRotate : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;
        private float _mousePositionX;
        private DeviceInput _input;

        private void Awake()
        {
            _input = GetComponent<DeviceInput>();
        }
        
        private void FixedUpdate()
        {
            _mousePositionX = _input.GetHorizontalRotation();

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