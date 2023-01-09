using Entities.Neutral;
using Factories.Components;
using MonoBehaviours.GameObjects.MonoEntity.Player;
using UnityEngine;

namespace Factories
{
    public class PlayerFactory : EntityFactory<PlayerMono>
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