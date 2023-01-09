using MonoBehaviours.GameObjects.Items;
using Objects.Interfaces;
using UnityEngine;

namespace MonoBehaviours.GameObjects.MonoEntity
{
    public class PlayerSphereColliding : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _collidingMask;

        [Header("Is Display Gizmo?")] [SerializeField]
        private bool _isDisplayGizmo;

        private const int MAX_COLLIDERS = 10;
        private readonly Collider[] _colliders = new Collider[MAX_COLLIDERS];

        private void FixedUpdate()
        {
            CollideFromSphere();
        }

        private void CollideFromSphere()
        {
            Physics.OverlapSphereNonAlloc(transform.position, _radius, _colliders, _collidingMask);

            for (var i = 0; i < _colliders.Length; i++)
            {
                var destroyable = GetCollidingItem(_colliders[i]);
                if (destroyable != null)
                {
                    destroyable.Collide();
                    _colliders[i] = null;
                }
            }
        }
        
        private static ICollidingItem GetCollidingItem(Collider colliding)
        {
            return colliding != null && colliding.
                TryGetComponent(out ICollidingItem item) ?
                item : null;
        }

        private void OnDrawGizmos()
        {
            if (!_isDisplayGizmo) return;
            
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, _radius);
            Gizmos.color = Color.white;
        }
    }
}