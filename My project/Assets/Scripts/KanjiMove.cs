using UnityEngine;

public class KanjiMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector3 moveDirection;

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // ‰æ–ÊŠO‚Éo‚½‚çíœ
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPos.x < -0.1f || screenPos.x > 1.1f ||
            screenPos.y < -0.1f || screenPos.y > 1.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
{
    if (!collision.gameObject.CompareTag("Player"))
        return;

    if (CompareTag("Effect"))
    {
            GetComponent<PlayerHealth>().TakeDamage(10);
            // Œø‰Ê‚ğ”­“®‚·‚éˆ—‚ÍŒã‚Å’Ç‰Á
            Destroy(gameObject);
    }
    else if (CompareTag("Obstacle"))
    {
        // Á‚³‚¸‚Éc‚·
    }
}
}
