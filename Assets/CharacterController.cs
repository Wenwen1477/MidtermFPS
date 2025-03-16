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
    private bool canJump = true; // ����÷����㹡������ҵ���Ф�����ö���ⴴ��

    void Update()
    {
        // ����ҵ���Ф��о���������
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // ��ͧ�ѹ����Ф����
            canJump = true; // ����Ф�����ö���ⴴ��������о��
        }

        // �Ѻ��ҡ������͹���ҡ������
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // �� Space ���͡��ⴴ
        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // �ӹǳ�������ǡ��ⴴ
            canJump = false; // ��ͧ�ѹ��á��ⴴ��Ө����Ҩ�ŧ���
        }

        // �� Gravity
        velocity.y += gravity * Time.deltaTime;

        // ����͹������ CharacterController
        controller.Move(velocity * Time.deltaTime);
    }
}


