using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject impactEffect; // เอฟเฟกต์ระเบิด
    public int damage = 10; // ค่าดาเมจ

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // ถ้ากระสุนชนศัตรู
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // ทำดาเมจศัตรู
            }

            // สร้างเอฟเฟกต์ระเบิดแล้วทำลายกระสุน
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

