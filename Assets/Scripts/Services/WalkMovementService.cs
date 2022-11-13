using UnityEngine;
using Zenject;

namespace Services
{
    public class WalkMovementService : IMovementService
    {
        private Player _player;

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }

        public void MoveInDirectionWithSpeed(Vector3 direction, float speed)
        {
            float fixedSpeed = speed * Time.deltaTime;
            _player.transform.position += direction * fixedSpeed;
        }
    }
}