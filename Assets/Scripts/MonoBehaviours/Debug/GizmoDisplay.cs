using UnityEngine;

namespace MonoBehaviours.Debug
{
    public class GizmoDisplay : MonoBehaviour
    {
        [SerializeField] private float _radius;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, _radius);
            Gizmos.color = Color.white;
        }
    }
}