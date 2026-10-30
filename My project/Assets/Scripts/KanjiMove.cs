using UnityEngine;

public class KanjiMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed; // ˆÚ“®‘¬“x
    private Vector3 velocity;                 // ˆÚ“®•ûŒü
    private Rigidbody rb;
    private bool isHitPlayer = false;

    void Update()
    {

    }

    private void KanjiCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isHitPlayer = true;
        }
    }
}
