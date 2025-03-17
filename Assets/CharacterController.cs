using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 10f;
    public float jumpForce = 5f;
    public CharacterController controller;

    private Vector3 playerVelocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
        CheckGround(); // ป้องกันตัวละครจมลงดิน
    }

    void MovePlayer()
    {
        isGrounded = controller.isGrounded;

        // ป้องกันตัวละครทะลุพื้น
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        // รับค่าการเคลื่อนที่จากปุ่มกด
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * vertical + transform.right * horizontal;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // กระโดด
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
        }

        // ใช้ Gravity
        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void CheckGround()
    {
        // ยิง Raycast ลงไปเช็กพื้น
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
            if (hit.collider != null)
            {
                Vector3 newPosition = transform.position;
                newPosition.y = hit.point.y + 0.1f; // ดันตัวละครให้อยู่เหนือพื้น
                transform.position = newPosition;
            }
        }

        // ถ้าตัวละครต่ำกว่าระดับพื้น (กันตกฉาก)
        if (transform.position.y < -5)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = 1f; // ย้ายตัวละครขึ้นมาใหม่
            transform.position = newPosition;
        }
    }
}
