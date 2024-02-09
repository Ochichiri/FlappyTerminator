using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private float _minSpeed = 0;
    private float _maxSpeed = 10;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
        transform.Translate(transform.right * Time.deltaTime * _speed);
    }
}