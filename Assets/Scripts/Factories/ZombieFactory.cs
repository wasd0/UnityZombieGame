using UnityEngine;
using Zenject;

namespace Factories
{
    public class ZombieFactory : EntityFactory<Zombie>
    {
        public override Vector3 SpawnPosition { get; protected set; }
        public override string PrefabPath { get; protected set; }
        
        private const string ZOMBIE_PATH = "Zombie";

        [Inject]
        private void Construct(ZombieSpawnPosition zombieSpawnPosition)
        {
            SpawnPosition = zombieSpawnPosition.Point.position;
            PrefabPath = ZOMBIE_PATH;
        }
    }
}