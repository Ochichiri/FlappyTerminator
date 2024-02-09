using System.Collections;
using UnityEngine;

public class AllyBullet : MonoBehaviour
{
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(DestroyWithDelay());
    }

    private IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(_delay);
        Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.gameObject.SetActive(false);
        }
    }
}