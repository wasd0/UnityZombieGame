using Entities;
using Entities.Neutral;
using Factories.Components;
using UnityEngine;

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