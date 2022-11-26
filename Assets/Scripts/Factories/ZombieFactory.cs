using Entities.Enemy;
using Factories.Components;
using Services;
using UnityEngine;
using UnityObjects;
using Zenject;

namespace Factories
{
    public class ZombieFactory : EntityFactory<Zombie>
    {
        private const string ZOMBIE_PATH = "Prefabs/Zombie";
        
        protected override Vector3 SpawnPosition { get; set; }
        protected override string PrefabPath { get; set; }
        
        [Inject]
        private void Construct(ZombieSpawnPosition zombieSpawnPosition)
        {
            SpawnPosition = zombieSpawnPosition.Point.position;
            PrefabPath = ZOMBIE_PATH;
        }

        protected override void InitializeMovementForEntity(Zombie zombie)
        {
            _diContainer.InstantiateComponent<ZombieMovementSystem>(zombie.gameObject);
            zombie.GetComponent<ZombieMovementSystem>().SetMovementService(new WalkMovementService());
        }
    }
}