using Services;
using UnityEngine;
using UnityObjects;
using Zenject;

namespace Factories
{
    public class ZombieFactory : IFactory<Zombie>
    {
        private Vector3 _spawnPosition;
        private const string ZOMBIE_PATH = "Prefabs/Zombie";
        private DiContainer _diContainer;

        [Inject]
        private void Construct(DiContainer diContainer, ZombieSpawnPosition zombieSpawnPosition)
        {
            _spawnPosition = zombieSpawnPosition.Point.position;
            _diContainer = diContainer;
        }

        public Zombie Create()
        {
            Vector3 spawnPosition = _spawnPosition;

            var zombie = _diContainer.InstantiatePrefabResourceForComponent<Zombie>(
                ZOMBIE_PATH, spawnPosition,
                Quaternion.identity, null);
            InitializeMovementForZombie(zombie);
            zombie.name = typeof(Zombie).ToString();
            return zombie;
        }

        private void InitializeMovementForZombie(Zombie zombie)
        {
            _diContainer.InstantiateComponent<ZombieMovementSystem>(zombie.gameObject);
            zombie.GetComponent<ZombieMovementSystem>().SetMovementService(new WalkMovementService());
        }
    }
}