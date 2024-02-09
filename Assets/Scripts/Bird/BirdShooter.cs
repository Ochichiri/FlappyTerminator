using UnityEngine;

public class BirdShooter : MonoBehaviour
{
    [SerializeField] private AllyBullet _bullet;
    [SerializeField] private Transform _bulletContainer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, transform.position, transform.rotation, _bulletContainer);
    }
}