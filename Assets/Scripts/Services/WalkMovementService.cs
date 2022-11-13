using UnityEngine;
using Zenject;

namespace Services
{
    public class WalkMovementService<T> : IMovementService<T>
        where T : Entity
    {
        private T _entity;

        [Inject]
        private void Construct(T entity)
        {
            _entity = entity;
        }

        public void MoveInDirectionWithSpeed(Vector3 direction, float speed)
        {
            float fixedSpeed = speed * Time.deltaTime;
            _entity.transform.position += direction * fixedSpeed;
        }
    }
}