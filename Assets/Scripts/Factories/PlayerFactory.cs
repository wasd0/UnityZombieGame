using Entities;
using Factories.Components;
using MonoBehaviours;
using Services;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class PlayerFactory : EntityFactory<Player>
    {
        private const string PLAYER_PATH = "Prefabs/Player";
        
        protected override Vector3 SpawnPosition { get; }
        protected override string PrefabPath { get; }
        
        private PlayerFactory(PlayerSpawnPosition playerSpawnPosition)
        {
            SpawnPosition = playerSpawnPosition.PointTransform.position;
            PrefabPath = PLAYER_PATH;
        }
    }
}