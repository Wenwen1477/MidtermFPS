using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1300; // ��ѧ���Ե�ͧ�ѵ��

    // �ѧ��ѹ����Ѻ������ҡ����ع
    public void TakeDamage(int damage)
    {
        health -= damage; // Ŵ��ѧ���Ե�ͧ�ѵ��
        if (health <= 0)
        {
            Die(); // ��Ҿ�ѧ���Ե������ӡ�õ��
        }
    }

    // �ѧ��ѹ������¡������ѵ�ٵ��
    void Die()
    {
        // ����ö�����ѧ��ѹ��õ�� �� ������§, �ʴ��Ϳ࿡��, ź�ѵ��
        Destroy(gameObject); // ź�ѵ���͡�ҡ�ҡ
    }
}
