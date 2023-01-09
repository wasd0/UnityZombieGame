using UnityEngine;

namespace MonoBehaviours.GameObjects.Entity
{
    public class Gravitation : MonoBehaviour
    {
        private CharacterController _characterController;
        
        private Vector3 fallVelocity;
        private const float GRAVITY = -9.81f;

        private void Update()
        {
            TryFall();
        }

        private void TryFall()
        {
            var isGrounded = _characterController.isGrounded;
            
            if (isGrounded && fallVelocity.y < 0)
            {
                fallVelocity.y = -2f;
            }

            fallVelocity.y += GRAVITY * Time.deltaTime;

            _characterController.Move(fallVelocity * Time.deltaTime);
        }

        private void OnEnable()
        {
            _characterController = GetComponent<CharacterController>();
        }
    }
}