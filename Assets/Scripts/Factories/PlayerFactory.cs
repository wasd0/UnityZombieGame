using UnityEngine;
using Zenject;

namespace Factories
{
    public class PlayerFactory : IFactory<Player>
    {
        [Inject(Id = SpawnPosition.Markers.Player)]
        private SpawnPosition _spawnPosition;
        private const string PLAYER_PATH = "Player";
        private DiContainer _diContainer;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public Player CreatePlayer()
        {
            Vector3 spawnPosition = _spawnPosition.Point.transform.position;
        
            var player = _diContainer.
                InstantiatePrefabResourceForComponent<Player>(
                    PLAYER_PATH, spawnPosition,
                    Quaternion.identity, null);
            player.name = typeof(Player).ToString();
            return player;
        }
    }
}