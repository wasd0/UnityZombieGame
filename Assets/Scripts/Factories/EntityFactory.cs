using UnityEngine;
using Zenject;

namespace Factories
{
    public abstract class EntityFactory<T> : IFactory<T>
        where T : Entity
    {
        public abstract Vector3 SpawnPosition { get; protected set; }
        public abstract string PrefabPath { get; protected set; }

        private DiContainer _diContainer;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T Create()
        {
            Vector3 spawnPosition = SpawnPosition;

            var entity = _diContainer.InstantiatePrefabResourceForComponent<T>(
                PrefabPath, spawnPosition,
                Quaternion.identity, null);

            entity.name = typeof(T).ToString();
            return entity;
        }
    }
}