using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100; // ��� HP �������
    private int currentHealth;
    private bool isDead = false; // ����ҵ�������ѧ

    void Start()
    {
        currentHealth = maxHealth; // �絤�� HP �͹�������
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // ��ҵ������ ��ش��÷ӧҹ

        currentHealth -= damage; // Ŵ HP
        Debug.Log("Enemy HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return; // ��ͧ�ѹ������¡���
        isDead = true; // ���ʶҹ��繵������

        Debug.Log("Enemy Died!");
        Destroy(gameObject, 2f); // ź GameObject �͡�ҡ�ҡ��ѧ�ҡ 2 ��
    }
}
