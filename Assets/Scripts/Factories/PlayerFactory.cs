using Services;
using UnityEngine;
using UnityObjects;
using Zenject;

namespace Factories
{
    public class PlayerFactory : IFactory<Player>
    {
        private Vector3 _spawnPosition;
        private const string PLAYER_PATH = "Prefabs/Player";
        private DiContainer _diContainer;

        [Inject]
        private void Construct(DiContainer diContainer, PlayerSpawnPosition playerSpawnPosition)
        {
            _spawnPosition = playerSpawnPosition.PointTransform.position;
            _diContainer = diContainer;
        }

        public Player Create()
        {
            Vector3 spawnPosition = _spawnPosition;

            var player = _diContainer.InstantiatePrefabResourceForComponent<Player>(
                PLAYER_PATH, spawnPosition,
                Quaternion.identity, null);
            player.name = typeof(Player).ToString();
            InitializeMovementForPlayer(player);
            return player;
        }

        private void InitializeMovementForPlayer(Player player)
        {
            _diContainer.InstantiateComponent<PlayerMovementSystem>(player.gameObject);
            player.GetComponent<PlayerMovementSystem>().SetMovementService(new WalkMovementService());
        }
    }
}