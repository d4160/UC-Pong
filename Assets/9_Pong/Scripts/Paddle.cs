using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Paddle : MonoBehaviour
{
    public float speed = 12f;
    public bool moveWithAcceleration = false;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        if (moveWithAcceleration)
        {
            if (direction != Vector3.zero)
                MoveWithForce(direction, speed);
        }
        else
        {
            MoveWithVelocity(direction, speed);
        }
    }

    void MoveWithVelocity(Vector3 direction, float magnitud)
    {
        _rb.velocity = direction * magnitud;
    }

    void MoveWithForce(Vector3 direction, float magnitud)
    {
        _rb.AddForce(direction * magnitud * 3.5f, ForceMode.Acceleration);
    }
}
