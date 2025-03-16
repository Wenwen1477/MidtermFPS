using UnityEngine;

public class FireballShooter : MonoBehaviour
{
    public GameObject fireballPrefab; // ตั้ง Prefab ของกระสุน
    public Transform firePoint; // จุดที่กระสุนเกิด
    public float fireballSpeed = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // กดคลิกซ้ายเพื่อยิง
        {
            ShootFireball();
        }
    }

    void ShootFireball()
    {
        // สร้างกระสุน
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);

        // ดันกระสุนไปข้างหน้าด้วย Rigidbody
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * fireballSpeed;
        }

        // ?? ลบกระสุนหลังจาก 3 วินาที ??
        Destroy(fireball, 3f);
    }
}
