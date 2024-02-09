using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool _pool;

    private void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    private void OnEnable()
    {
        _bird.GameOver += Restart;
    }

    private void OnDisable()
    {
        _bird.GameOver -= Restart;
    }

    private IEnumerator GenerateEnemies()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (enabled)
        {
            SpawnEnemy();
            yield return delay;
        }
    }

    private void SpawnEnemy()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Enemy pipe = _pool.GetObject();

        pipe.gameObject.SetActive(true);
        pipe.transform.position = spawnPoint;
    }

    public void Restart()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}