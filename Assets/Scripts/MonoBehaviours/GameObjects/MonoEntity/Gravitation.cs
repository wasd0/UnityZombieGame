using UnityEngine;

namespace MonoBehaviours.GameObjects.MonoEntity
{
    public class Gravitation : MonoBehaviour
    {
        private CharacterController _characterController;
        private Vector3 _fallVelocity;
        private const float GRAVITY = -9.81f;

        private void Update()
        {
            TryFall();
        }

        private void TryFall()
        {
            var isGrounded = _characterController.isGrounded;
            
            if (isGrounded && _fallVelocity.y < 0)
            {
                _fallVelocity.y = -2f;
            }

            _fallVelocity.y += GRAVITY * Time.deltaTime;

            _characterController.Move(_fallVelocity * Time.deltaTime);
        }

        private void OnEnable()
        {
            _characterController = GetComponent<CharacterController>();
        }
    }
}