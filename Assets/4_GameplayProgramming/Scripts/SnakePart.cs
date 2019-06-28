using UnityEngine;
using System.Collections;

public class SnakePart : MonoBehaviour
{
    private SnakePart _next;
    private Vector3 _offsetFromNext;
    private bool _rotated;

    private float _waitToRotateTimer;
    private float _waitToRotate;
    private Vector3 _rotation;

    public SnakePart Next
    {
        get {
            return _next;
        }
        set {
            _next = value;

            if (_next)
            {
                _offsetFromNext = _next.transform.position - transform.position;
            }
        }
    }

    public bool Rotated { get => _rotated; set => _rotated = value; }

    public Vector3 Rotation { get => _rotation; set => _rotation = value; }

    public float WaitToRotate { get => _waitToRotate; set => _waitToRotate = value; }

    private void Update()
    {
        if (_next)
        {
            transform.position = _next.transform.position - _offsetFromNext;

            if (_next.Rotated)
            {
                _next.Rotated = false;
                _rotation = _next.Rotation;

                _waitToRotateTimer = _waitToRotate;
            }

            if (_waitToRotateTimer > 0)
            {
                _waitToRotateTimer -= Time.deltaTime;

                if (_waitToRotateTimer <= 0)
                {
                    Rotate();

                    _rotated = true;
                }
            }
        }
    }

    public void Rotate()
    {
        transform.localEulerAngles = _rotation;
    }
}
