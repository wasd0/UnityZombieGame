using MonoBehaviours;
using UnityEngine;
using Zenject;

public class Billboard : MonoBehaviour
{
    private Transform _camera;

    [Inject]
    private void Construct(CameraFollow cameraFollow)
    {
        _camera = cameraFollow.transform;
    }
    
    private void FixedUpdate()
    {
        transform.LookAt(transform.position + _camera.forward);
    }
}
