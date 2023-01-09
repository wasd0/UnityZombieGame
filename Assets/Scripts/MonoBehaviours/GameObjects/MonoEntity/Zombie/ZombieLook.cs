using MonoBehaviours.GameObjects.MonoEntity.Player;
using UnityEngine;
using Zenject;

namespace MonoBehaviours.GameObjects.MonoEntity.Zombie
{
    public class ZombieLook : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 2;

        private PlayerMovementTest _player;

        [Inject]
        private void Construct(PlayerMovementTest player)
        {
            _player = player;
        }

        private void Update()
        {
            LookAtPlayer();
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