using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _enemyContainer;
    [SerializeField] private Transform _bulletContainer;
    [SerializeField] private Enemy _prefab;

    private Queue<Enemy> _pool;

    public IEnumerable<Enemy> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<Enemy>();
    }

    public Enemy GetObject()
    {
        if (_pool.Count == 0)
        {
            var enemy = Instantiate(_prefab);
            enemy.transform.parent = _enemyContainer;
            enemy.GetComponent<EnemyShooter>().Init(_bulletContainer);

            return enemy;
        }

        return _pool.Dequeue();
    }

    public void PutObject(Enemy enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}