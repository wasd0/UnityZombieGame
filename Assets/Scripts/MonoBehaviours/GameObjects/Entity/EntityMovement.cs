using UnityEngine;

namespace MonoBehaviours.GameObjects.Entity
{
    [RequireComponent(typeof(CharacterController))]
    public abstract class EntityMovement : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundMask;

        private Vector3 fallVelocity;
        
        private const float GROUND_DISTANCE = 0.4f;
        private const float GRAVITY = -9.81f;

        protected abstract CharacterController CharacterController { get; }

        private void FixedUpdate()
        {
            TryFall();
        }

        private void TryFall()
        {
            if (OnGround() && fallVelocity.y < 0)
            {
                fallVelocity.y = -2f;
            }

            fallVelocity.y += GRAVITY * Time.deltaTime;

            CharacterController.Move(fallVelocity * Time.deltaTime);
        }

        private bool OnGround()
        {
            return Physics.CheckSphere(_groundCheck.position, GROUND_DISTANCE, _groundMask);
        }

        protected abstract void Move();
    }
}