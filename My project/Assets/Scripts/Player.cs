using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed; // 移動速度
    [SerializeField] public float jumpPower;  // ジャンプの強さ
    private Vector3 velocity;                 // 移動方向
    private Rigidbody rb;
    private bool isGrounded = true;           // 地面にいるかどうかの判定

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            velocity.x -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity.x += 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                jumpPower,
                rb.linearVelocity.z
            );

            isGrounded = false; // 空中での連続ジャンプを防ぐ
        }

        // 移動処理
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        if (velocity.magnitude > 0)
        {
            transform.position += velocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}