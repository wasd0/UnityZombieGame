using UnityEngine;
using Zenject;

public class WalkMovementService : IMovementService
{
    private PlayerEntity _player;

    [Inject]
    private void Construct(PlayerEntity playerEntity)
    {
        _player = playerEntity;
    }

    public void MoveInDirectionWithSpeed(Vector3 direction, float speed)
    {
        float fixedSpeed = speed * Time.deltaTime;
        _player.transform.position += direction * fixedSpeed;
    }
}