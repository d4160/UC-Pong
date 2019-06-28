using UnityEngine;

public class Snake : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 startingDirection = new Vector2(1, 0);

    private Vector3 _direction;
    private Transform _t;
    private SnakePart[] _parts;

    public SnakePart Head => _parts[0];

    public float TimeToRotate => speed / 2;

    private void Awake()
    {
        _t = transform;

        _parts = GetComponentsInChildren<SnakePart>();

        if (_parts.Length > 1)
        {
            for (int i = _parts.Length - 1; i > 0; i--)
            {
                _parts[i].Next = _parts[i - 1];
                _parts[i].WaitToRotate = TimeToRotate;
            }
        }
    }

    private void Start()
    {
        _direction = new Vector3(startingDirection.x, 0, startingDirection.y);
    }

    void Update()
    {
        CheckInput();

        Head.transform.Translate(_direction * speed * Time.deltaTime, Space.World);
    }

    float _prevH, _prevV;

    void CheckInput()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        if (h != 0 && h != _prevH)
        {
            _direction = new Vector3(h, 0, 0);

            _prevH = h;
            _prevV = 0;

            FlipDirection();
        }
        else if (v != 0 && v != _prevV)
        {
            _direction = new Vector3(0, 0, v);

            _prevV = v;
            _prevH = 0;

            FlipDirection();
        }
    }

    void FlipDirection()
    {
        Vector3 rot = Vector3.zero; ;

        if (_direction.x == 1)
        {
            rot = Vector3.zero; 
        }
        else if (_direction.x == -1)
        {
            rot = Vector3.up * 180f;
        }
        else if (_direction.z == 1)
        {
            rot = Vector3.up * -90f;
        }
        else if (_direction.z == -1)
        {
            rot = Vector3.up * 90f;
        }

        Head.Rotation = rot;
        Head.Rotate();
    }
}
