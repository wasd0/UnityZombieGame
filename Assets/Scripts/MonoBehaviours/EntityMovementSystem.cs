using UnityEngine;

namespace MonoBehaviours
{
    public abstract class EntityMovementSystem : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundMask;

        protected abstract CharacterController CharacterController { get; set; }
        
        private Vector3 fallVelocity;
        private const float GROUND_DISTANCE = 0.4f;

        private void Update()
        {
            ReadAxis();
            Move();
            TryFall();
        }

        protected abstract void ReadAxis();

        protected abstract void Move();

        private void TryFall()
        {
            if (OnGround() && fallVelocity.y < 0)
            {
                fallVelocity.y = -2f;
            }
            
            float gravity = -9.81f;
            fallVelocity.y += gravity * Time.deltaTime;

            CharacterController.Move(fallVelocity * Time.deltaTime);
        }
        
        private bool OnGround()
        {
            return Physics.CheckSphere(_groundCheck.position, GROUND_DISTANCE, _groundMask);
        }
    }
}