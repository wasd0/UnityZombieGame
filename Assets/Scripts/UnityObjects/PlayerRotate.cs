using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityObjects
{
    [RequireComponent(typeof(KeyboardInput))]
    public class PlayerRotate : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;
        private float _mousePositionX;
        private KeyboardInput _input;

        private void Awake()
        {
            _input = GetComponent<KeyboardInput>();
        }

        private void FixedUpdate()
        {
            RotateToMouse();
        }

        private void Update()
        {
            _mousePositionX = _input.GetHorizontalRotation();
            _mousePositionX = Mathf.Clamp(_mousePositionX, -90, 90);
        }

        private void RotateToMouse()
        {
            float relativeSpeed = _rotateSpeed * Time.deltaTime;
            Quaternion relativeRotate = Quaternion.Euler(0, _mousePositionX, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, relativeRotate, relativeSpeed);
        }
    }
}