using Entities;
using Factories.Components;
using Services;
using UnityEngine;
using UnityObjects;
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

        protected override void InitializeMovementForEntity(Player player)
        {
            _diContainer.InstantiateComponent<PlayerMovementSystem>(player.gameObject);
        }
    }
}