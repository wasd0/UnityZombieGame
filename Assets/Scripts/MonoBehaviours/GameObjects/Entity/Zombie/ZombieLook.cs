using Services;
using UnityEngine;
using Zenject;

namespace MonoBehaviours.GameObjects.Entity.Zombie
{
    public class ZombieLook : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 2;
        [SerializeField] private float _minDistanceToPlayer = 20;
        
        private Entities.Neutral.Player _player;

        [Inject]
        private void Construct(Entities.Neutral.Player player)
        {
            _player = player;
        }

        private void Update()
        {
            if (ZombieLocator.CompareDistance(_player, transform, _minDistanceToPlayer))
            {
                LookAtPlayer();
            }
        }

        private void LookAtPlayer()
        {
            Vector3 relativePos = _player.transform.position - transform.localPosition;
            float relativeSpeed = _rotationSpeed * Time.deltaTime;
            var newRotation =
                Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(relativePos), relativeSpeed);
            transform.rotation = new Quaternion(0, newRotation.y, 0, newRotation.w);
        }
    }
}