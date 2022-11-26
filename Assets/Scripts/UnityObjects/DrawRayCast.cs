using UnityEngine;

namespace UnityObjects
{
    public class DrawRayCast : MonoBehaviour
    {
        [SerializeField] private float _distance;

        void Update()
        {
            Debug.DrawRay(transform.localPosition, transform.forward * _distance, Color.red);
        }
    }
}
