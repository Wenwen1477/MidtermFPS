using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100; // ค่า HP เริ่มต้น
    private int currentHealth;
    private bool isDead = false; // เช็คว่าตายหรือยัง

    void Start()
    {
        currentHealth = maxHealth; // เซ็ตค่า HP ตอนเริ่มเกม
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // ถ้าตายแล้ว หยุดการทำงาน

        currentHealth -= damage; // ลด HP
        Debug.Log("Enemy HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return; // ป้องกันการเรียกซ้ำ
        isDead = true; // ตั้งสถานะเป็นตายแล้ว

        Debug.Log("Enemy Died!");
        Destroy(gameObject, 2f); // ลบ GameObject ออกจากฉากหลังจาก 2 วิ
    }
}
