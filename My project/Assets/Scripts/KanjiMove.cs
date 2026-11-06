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
    }
}
