using UnityEngine;
using Zenject;

namespace Factories
{
    public class PlayerFactory : EntityFactory<Player>
    {
        public override Vector3 SpawnPosition { get; protected set; }
        public override string PrefabPath { get; protected set; }
        
        private const string PLAYER_PATH = "Prefabs/Player";
        
        [Inject]
        private void Construct(PlayerSpawnPosition playerSpawnPosition)
        {
            SpawnPosition = playerSpawnPosition.PointTransform.position;
            PrefabPath = PLAYER_PATH;
        }
    }
}