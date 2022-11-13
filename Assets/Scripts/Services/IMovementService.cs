using UnityEngine;

public interface IMovementService<T>
    where T : Entity
{
    public void MoveInDirectionWithSpeed(Vector3 direction, float speed);
}