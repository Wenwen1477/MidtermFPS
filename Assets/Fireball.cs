using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject impactEffect; // เอฟเฟกต์ระเบิด
    public int damage = 10; // ค่าดาเมจ

    void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าเมื่อกระสุนชนกับวัตถุที่มี Tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // ค้นหาคอมโพเนนต์ EnemyHealth ในศัตรู
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // ส่งดาเมจไปให้ศัตรู
            }

            // สร้างเอฟเฟกต์ระเบิด
            GameObject effect = Instantiate(impactEffect, transform.position, Quaternion.identity);

            // ทำลายเอฟเฟกต์หลังจาก 3 วินาที
            Destroy(effect, 3f);

            // ลบกระสุน
            Destroy(gameObject);
        }
    }
}

