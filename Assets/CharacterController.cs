using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f; // ความเร็วในการเดิน
    public float jumpHeight = 2f; // ความสูงของการกระโดด
    public float gravity = -9.81f; // ค่าแรงโน้มถ่วง
    public float groundCheckDistance = 0.3f; // ระยะตรวจจับพื้น
    public LayerMask groundMask; // Mask สำหรับพื้น

    private Vector3 velocity;
    private bool isGrounded;
    private bool canJump = true; // ตัวแปรที่ใช้ในการเช็คว่าตัวละครสามารถกระโดดได้

    void Update()
    {
        // เช็คว่าตัวละครแตะพื้นหรือไม่
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // ป้องกันตัวละครลอย
            canJump = true; // ตัวละครสามารถกระโดดได้เมื่อแตะพื้น
        }

        // รับค่าการเคลื่อนที่จากปุ่มกด
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // กด Space เพื่อกระโดด
        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // คำนวณความเร็วกระโดด
            canJump = false; // ป้องกันการกระโดดซ้ำจนกว่าจะลงพื้น
        }

        // ใช้ Gravity
        velocity.y += gravity * Time.deltaTime;

        // เคลื่อนที่ด้วย CharacterController
        controller.Move(velocity * Time.deltaTime);
    }
}


