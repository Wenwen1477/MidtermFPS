using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;           // ����÷���纵���Ф�
    public float mouseSensitivity = 2.0f;  // �����Ǣͧ�����
    public float verticalLookLimit = 80f;  // �ӡѴ����ͧ���/ŧ

    private float xRotation = 0f;     // ��������ع���ͧ��� X (������/ŧ)

    void Update()
    {
        // �Ѻ��ҡ������͹���ͧ�����
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // ��ع���ͧ����ǹ͹ (����/���)
        transform.Rotate(Vector3.up * mouseX);

        // �ӹǳ�����ع��ǵ�� (���/ŧ) ��ШӡѴ����ͧ
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalLookLimit, verticalLookLimit);  // �ӡѴ����������Թ 80 ͧ��

        // ��ع���ͧ��ǵ�� (����ͧ���/ŧ)
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
