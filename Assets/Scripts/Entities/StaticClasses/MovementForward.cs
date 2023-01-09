using UnityEngine;

namespace Entities.StaticClasses
{
    public static class MovementForward
    {
        public static void MoveForward(Transform currentTransform, CharacterController characterController, float speed)
        {
            var relativeSpeed = speed * Time.deltaTime;
            characterController.Move(currentTransform.forward * relativeSpeed);
        }
    }
}