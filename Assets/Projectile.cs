using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 20; // พลังโจมตีของกระสุน
    public float speed = 10f;
    public float lifetime = 3f; // กระสุนจะหายไปหลังจาก 3 วินาที

    void Start()
    {
        Destroy(gameObject, lifetime); // ลบกระสุนอัตโนมัติหลังจากระยะเวลาที่กำหนด
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // ตรวจจับเฉพาะศัตรู
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject); // ทำลายกระสุนหลังจากชน
        }
        else if (!other.CompareTag("Player") && !other.CompareTag("Projectile"))
        {
            Destroy(gameObject); // ทำลายกระสุนเมื่อชนวัตถุอื่นที่ไม่ใช่ผู้เล่น
        }
    }
}

