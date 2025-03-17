using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;   // ����÷��������ͧ�Դ��� (����Ф�)
    public Vector3 offset;     // ������ҧ�����ҧ���ͧ�Ѻ����Ф�

    void Start()
    {
        // ����ѧ������駤�� offset �е�駤���繤�һ���
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 1.5f, -5);  // ������ҧ�����ͧ�����٧��������ҧ�͡�
        }
    }

    void LateUpdate()
    {
        // �����ͧ�Դ�������Фõ�����˹����������ҧ
        transform.position = player.position + offset;

        // �����ͧ��ع��������ع�ͧ����Ф�
        transform.LookAt(player);
    }
}
