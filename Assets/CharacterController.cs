using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f; // ��������㹡���Թ
    public float jumpHeight = 2f; // �����٧�ͧ��á��ⴴ
    public float gravity = -9.81f; // ����ç�����ǧ
    public float groundCheckDistance = 0.3f; // ���е�Ǩ�Ѻ���
    public LayerMask groundMask; // Mask ����Ѻ���

    private Vector3 velocity;
    private bool isGrounded;

    void Update()
    {
        // ����ҵ���Ф��о���������
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // ��ͧ�ѹ����Ф����
        }

        // �Ѻ��ҡ������͹���ҡ������
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // �� Space ���͡��ⴴ
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // �� Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
