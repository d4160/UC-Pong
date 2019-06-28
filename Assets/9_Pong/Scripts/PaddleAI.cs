using UnityEngine;

[RequireComponent(typeof(Paddle))]
public class PaddleAI : MonoBehaviour
{
    private Paddle _paddle;
    private Ball _ball;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _paddle = GetComponent<Paddle>();
    }

    private void Start()
    {
        _ball = GameManager.Instance.PlayingBall;
    }

    private void Update()
    {
        Vector3 direction = Vector3.zero;

        if (_ball.transform.position.z > _transform.position.z)
        {
            direction = Vector3.forward;
        }
        else
        {
            direction = -Vector3.forward;
        }

        Move(direction);
    }

    private void Move(Vector3 direction)
    {
        _paddle.Move(direction);
    }
}
