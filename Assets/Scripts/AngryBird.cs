using UnityEngine;

public class AngryBird : MonoBehaviour
{

    [SerializeField] private AudioClip _hitclip;

    private Rigidbody2D _rb;
    private CircleCollider2D _circleCollider;

    private bool _hasBeenLaunched;
    private bool _shouldFaceVelocityDirection;

    private AudioSource _audioSource;



    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _rb.isKinematic = true;
        _circleCollider.enabled = false;
    }


    private void FixedUpdate()
    {
        if (_hasBeenLaunched && _shouldFaceVelocityDirection)
        {
            transform.right = _rb.velocity;
        }

    }

    public void LaunchBird(Vector2 direction, float force)
    {
        _rb.isKinematic = false;
        _circleCollider.enabled = true;

        _rb.AddForce(direction * force, ForceMode2D.Impulse);

        _hasBeenLaunched = true;
        _shouldFaceVelocityDirection = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _shouldFaceVelocityDirection = false;
        SoundManager.instance.PlayClip(_hitclip, _audioSource);
        Destroy(this);
    }
}
