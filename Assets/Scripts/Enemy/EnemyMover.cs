using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private float _minSpeed = 0;
    private float _maxSpeed = 10;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    private void Update()
    {
        Move();
    }

    private void OnValidate()
    {
        _speed = Mathf.Clamp(_speed, _minSpeed, _maxSpeed);
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(-_speed, 0);
    }
}