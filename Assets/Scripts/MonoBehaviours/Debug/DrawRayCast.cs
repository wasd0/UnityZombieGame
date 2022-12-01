using UnityEngine;

namespace MonoBehaviours.Debug
{
    public class DrawRayCast : MonoBehaviour
    {
        [SerializeField] private float _distance;

        void Update()
        {
            UnityEngine.Debug.DrawRay(transform.localPosition, transform.forward * _distance, color: Color.red);
        }
    }
}
