using UnityEngine;
using Zenject;

public class PlayerFactory : IFactory<PlayerEntity>
{
    private const string PLAYER_PATH = "Player";
    private DiContainer _diContainer;
    
    [Inject(Id = SpawnPosition.Markers.Player)]
    private SpawnPosition _spawnPosition;

    [Inject]
    private void Construct(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }
    
    public PlayerEntity Create()
    {
        Vector3 spawnPosition = _spawnPosition.Point.transform.position;
        
        return _diContainer.
            InstantiatePrefabResourceForComponent<PlayerEntity>(
                PLAYER_PATH, spawnPosition,
                Quaternion.identity, null);
    }
}