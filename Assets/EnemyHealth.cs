using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 50; // ���ʹ�ͧ�ѵ��

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + " ���Ѻ�����������: " + damage);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " �������!");
        Destroy(gameObject); // ������ѵ��
    }
}
