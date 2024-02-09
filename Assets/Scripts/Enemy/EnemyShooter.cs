using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private EnemyBullet _bullet;
    [SerializeField] private Transform _bulletContainer;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    public void Init(Transform bulletContainer)
    {
        _bulletContainer = bulletContainer;
    }

    private IEnumerator Shooting()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (enabled)
        {
            Shoot();
            yield return delay;
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, transform.position, Quaternion.Euler(0, 0, 90), _bulletContainer);
    }
}