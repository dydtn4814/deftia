using UnityEngine;

public class RigidbodyFPSController : MonoBehaviour
{
    // 이동 속도
    public float moveSpeed = 5f;
    // 점프 힘
    public float jumpForce = 5f;

    // Rigidbody 컴포넌트
    private Rigidbody rb;
    // 땅에 닿았는지 확인
    private bool isGrounded;

    void Start()
    {
        // Rigidbody 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody>();
        // 플레이어 캡슐이 회전하는 것을 방지합니다.
        rb.freezeRotation = true;
    }

    void Update()
    {
        // 땅에 닿았는지 지속적으로 확인
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        
        // 점프
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // WASD 이동
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;

        // 물리 엔진을 이용해 플레이어를 이동시킵니다.
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}