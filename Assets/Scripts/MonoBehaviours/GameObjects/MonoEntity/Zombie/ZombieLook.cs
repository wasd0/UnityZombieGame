using Entities.Enemy;
using MonoBehaviours.GameObjects.MonoEntity.Player;
using Services;
using UnityEngine;
using Zenject;

namespace MonoBehaviours.GameObjects.Entity.Zombie
{
    public class ZombieLook : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 2;
        [SerializeField] private float _minDistanceToPlayer = 20;
        
        private PlayerMono _playerMono;

        [Inject]
        private void Construct(PlayerMono playerMono)
        {
            _playerMono = playerMono;
        }

        private void Update()
        {
            if (DistanceCalculator.CompareDistance(_playerMono, transform, _minDistanceToPlayer))
            {
                LookAtPlayer();
            }
        }

        private void LookAtPlayer()
        {
            Vector3 relativePos = _playerMono.transform.position - transform.localPosition;
            float relativeSpeed = _rotationSpeed * Time.deltaTime;
            var newRotation =
                Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(relativePos), relativeSpeed);
            transform.rotation = new Quaternion(0, newRotation.y, 0, newRotation.w);
        }
    }
}