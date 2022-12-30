using Services;
using UnityEngine;
using Zenject;

namespace MonoBehaviours.GameObjects.Entity.Player
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;
        private ILookService _lookService;
        private float _rotateValue;

        [Inject]
        private void Construct(ILookService lookService)
        {
            _lookService = lookService;
        }

        private void FixedUpdate()
        {
            _rotateValue = _lookService.GetHorizontalAxis();
            RotateToMouse();
        }

        private void RotateToMouse()
        {
            var horizontalRotation = _rotateValue * _rotateSpeed * Time.fixedDeltaTime;
            
            transform.Rotate(Vector3.up * horizontalRotation);
        }
    }
}