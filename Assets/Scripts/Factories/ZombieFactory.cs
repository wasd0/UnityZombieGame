using Factories.Components;
using MonoBehaviours.GameObjects.MonoEntity.Zombie;
using UnityEngine;

namespace Factories
{
    public class ZombieFactory : EntityFactory<ZombieMono>
    {
        private const string ZOMBIE_PATH = "Prefabs/Zombie";
        
        protected override Vector3 SpawnPosition { get; }
        protected override string PrefabPath { get; }
        
        private ZombieFactory(ZombieSpawnPosition zombieSpawnPosition)
        {
            SpawnPosition = zombieSpawnPosition.Point.position;
            PrefabPath = ZOMBIE_PATH;
        }
    }
}