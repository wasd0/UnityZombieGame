using Services;
using Services.Interfaces;
using UnityEngine;
using Zenject;

namespace MonoBehaviours.GameObjects.Entity.Player
{
    public class LookTest : MonoBehaviour
    {
        [SerializeField] [Range(1, 20)] private float _rotateSpeed;
        private ILookInputService _lookInputService;
        private float _rotateValue;

        [Inject]
        private void Construct(ILookInputService lookInputService)
        {
            _lookInputService = lookInputService;
        }

        private void FixedUpdate()
        {
            _rotateValue = _lookInputService.GetHorizontalAxis();
            Rotate();
        }

        private void Rotate()
        {
            var horizontalRotation = _rotateValue * _rotateSpeed * Time.fixedDeltaTime;
            
            transform.Rotate(Vector3.up * horizontalRotation);
        }
    }
}