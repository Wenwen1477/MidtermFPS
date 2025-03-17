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
        CheckGround(); // ��ͧ�ѹ����Фè�ŧ�Թ
    }

    void MovePlayer()
    {
        isGrounded = controller.isGrounded;

        // ��ͧ�ѹ����Ф÷��ؾ��
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        // �Ѻ��ҡ������͹���ҡ������
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * vertical + transform.right * horizontal;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // ���ⴴ
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
        }

        // �� Gravity
        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void CheckGround()
    {
        // �ԧ Raycast ŧ��硾��
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
            if (hit.collider != null)
            {
                Vector3 newPosition = transform.position;
                newPosition.y = hit.point.y + 0.1f; // �ѹ����Ф���������˹�;��
                transform.position = newPosition;
            }
        }

        // ��ҵ���Фõ�ӡ����дѺ��� (�ѹ���ҡ)
        if (transform.position.y < -5)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = 1f; // ���µ���Фâ��������
            transform.position = newPosition;
        }
    }
}
