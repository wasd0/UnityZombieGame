using UnityEngine;
using Zenject;

namespace UnityObjects
{
    public class ZombieMovementSystem : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private IMovementService<Zombie> _movementService;

        [Inject]
        private void Construct(IMovementService<Zombie> movementService)
        {
            _movementService = movementService;
        }

        private void Update()
        {
            _movementService.MoveInDirectionWithSpeed(Vector3.forward, _speed);
        }
    }
}