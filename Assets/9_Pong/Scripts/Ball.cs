using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    public Vector2 minMaxSpeed = new Vector2(10, 14);

    [SerializeField] private ParticleSystem _destroyParticles;
    [Header("Audio")]
    [SerializeField] private AudioClip _hitClip;
    [SerializeField] private AudioClip _destroyClip;

    int _speedX;
    int _speedY;
    float _speed;
    AudioSource _source;
    Rigidbody _rb;
    Vector3 _startPosition;
    Renderer _ren;

    public Rigidbody Rb => _rb;
    public bool IsGoingToRight => _rb.velocity.x > 0;

    public bool IsAboveInZAxis(Vector3 other)
    {
        return transform.position.z > other.z; 
    }

    private void Awake()
    {
        _source = GetComponentInChildren<AudioSource>();
        _rb = GetComponent<Rigidbody>();
        _ren = GetComponentInChildren<Renderer>();
    }

    private void Start()
    {
        _startPosition = transform.position;

        SetRandomVelocity();
    }

    private void Update()
    {
        if (_rb.velocity.x == 0 || Mathf.Abs(_rb.velocity.z) < 0.5f)
        {
            var randomValue = Random.Range(minMaxSpeed.x / 2, minMaxSpeed.y / 2);
            var vel = _rb.velocity;

            if (_rb.velocity.x == 0)
            {
                vel.x = randomValue;
            }
            else
            {
                vel.z = randomValue;
            }

            _rb.velocity = vel;
        }
    }

    public void Reset()
    {
        RestoreStartPosition();
        SetActiveRenderer(true);
        SetRandomVelocity();
    }

    public void Destroy()
    {
        _rb.isKinematic = true;

        PlayDestroyParticles();
        PlayDestroyAudioClip();
        SetActiveRenderer(false);
    }

    private void SetRandomVelocity()
    {
        _speed = Random.Range(minMaxSpeed.x, minMaxSpeed.y);
        _speedX = Random.value > 0.5f ? 1 : -1;
        _speedY = Random.value > 0.5f ? 1 : -1;

        if (_rb)
        {
            _rb.isKinematic = false;
            _rb.velocity = new Vector3(_speedX * _speed, 0, _speedY * _speed);
        }
    }

    private void RestoreStartPosition()
    {
        transform.position = _startPosition;
    }

    private void PlayDestroyParticles()
    {
        if (_destroyParticles)
        {
            _destroyParticles.transform.position = transform.position;
            _destroyParticles.Play();
        }
    }

    private void PlayDestroyAudioClip()
    {
        if (_source)
        {
            _source.clip = _destroyClip;
            _source.Play();
        }
    }

    private void PlayHitAudioClip()
    {
        if (_source)
        {
            _source.clip = _hitClip;
            _source.Play();
        }
    }

    private void SetActiveRenderer(bool active)
    {
        if (_ren)
            _ren.enabled = active;
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayHitAudioClip();
    }

    private void OnDrawGizmos()
    {
        var pos = transform.position;

        if (_rb)
            Debug.DrawLine(pos, pos + _rb.velocity.normalized * 2f, Color.red);
    }
}
