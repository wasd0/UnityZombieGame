using Entities.Neutral;
using UnityEngine;
using Zenject;

namespace Factories
{
    public abstract class EntityFactory<T> : IFactory<T>
        where T : EntityComponents
    {
        [Inject] 
        protected readonly DiContainer _diContainer;

        protected abstract Vector3 SpawnPosition { get; }
        protected abstract string PrefabPath { get; }

        public T Create()
        {
            var entity = _diContainer.InstantiatePrefabResourceForComponent<T>(
                PrefabPath, SpawnPosition,
                Quaternion.identity, null);
            entity.name = entity.gameObject.tag;
            return entity;
        }
    }
}