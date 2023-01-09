using MonoBehaviours.GameObjects.Camera;
using UnityEngine;
using Zenject;

namespace MonoBehaviours.UI
{
    public class HealthBarViewer : MonoBehaviour
    {
        private Transform _cameraTransform;

        [Inject]
        private void Construct(CameraFollow cameraFollow)
        {
            _cameraTransform = cameraFollow.transform;
        }
    
        private void FixedUpdate()
        {
            LookAtCamera();
        }

        private void LookAtCamera()
        {
            transform.LookAt(transform.position + _cameraTransform.forward);
        }
    }
}
