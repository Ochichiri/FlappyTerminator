using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ScoreZone>())
        {
            collision.gameObject.transform.parent.gameObject.SetActive(false);
        }

        if (collision.TryGetComponent(out IInteractable interactable))
        {
            Destroy(collision.gameObject);
        }
    }
}
