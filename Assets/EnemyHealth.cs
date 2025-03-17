using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1300; // พลังชีวิตของศัตรู

    // ฟังก์ชันที่รับดาเมจจากกระสุน
    public void TakeDamage(int damage)
    {
        health -= damage; // ลดพลังชีวิตของศัตรู
        if (health <= 0)
        {
            Die(); // ถ้าพลังชีวิตหมดให้ทำการตาย
        }
    }

    // ฟังก์ชันที่เรียกเมื่อศัตรูตาย
    void Die()
    {
        // สามารถเพิ่มฟังก์ชันการตาย เช่น เล่นเสียง, แสดงเอฟเฟกต์, ลบศัตรู
        Destroy(gameObject); // ลบศัตรูออกจากฉาก
    }
}
