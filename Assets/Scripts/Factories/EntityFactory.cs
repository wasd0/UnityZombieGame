using Entities.Neutral;
using UnityEngine;
using Zenject;

namespace Factories
{
    public abstract class EntityFactory<T> : IFactory<T>
        where T : Entity
    {
        [Inject] protected readonly DiContainer _diContainer;
        
        protected abstract Vector3 SpawnPosition { get; set; }
        protected abstract string PrefabPath { get; set; }

        public T Create()
        {
            var entity = _diContainer.InstantiatePrefabResourceForComponent<T>(
                PrefabPath, SpawnPosition,
                Quaternion.identity, null);
            InitializeMovementForEntity(entity);
            entity.name = entity.gameObject.tag;
            return entity;
        }

        protected abstract void InitializeMovementForEntity(T entity);
    }
}