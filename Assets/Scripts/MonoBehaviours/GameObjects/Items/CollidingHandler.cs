using MonoBehaviours.GameObjects.Colliding;
using UnityEngine;

namespace MonoBehaviours.GameObjects.Items
{
    public class CollidingHandler : MonoBehaviour, ICollidingItem
    {
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _collidingMask;
        private const int MAX = 10;
        private readonly Collider[] _colliders = new Collider[MAX];

        private void FixedUpdate()
        {
            OverlapSphereNonAlloc();
        }

        private void OverlapSphereNonAlloc()
        {
            Physics.OverlapSphereNonAlloc(transform.position, _radius, _colliders, _collidingMask);

            for (var i = 0; i < _colliders.Length; i++)
            {
                if (_colliders[i] != null)
                {//TODO: Work
                    Collide(_colliders[i]);
                    _colliders[i] = null;
                }
            }
        }

        public void Collide(Collider other)
        {
            UnityEngine.Debug.Log($"{other.gameObject.name} collided with {name}");
        }
    }
}