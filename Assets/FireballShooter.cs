using UnityEngine;

public class FireballShooter : MonoBehaviour
{
    public GameObject fireballPrefab;  // ตัวอย่างของกระสุนไฟ (Prefab)
    public Transform firePoint;  // จุดที่ยิงกระสุนไฟออกไป
    public float fireballSpeed = 10f;  // ความเร็วของกระสุนไฟ
    public float fireRate = 0.5f;  // ค่าหน่วงเวลาระหว่างการยิงแต่ละครั้ง
    private float nextFireTime = 0f;  // ตัวจับเวลาสำหรับการยิง

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            ShootFireball();
            nextFireTime = Time.time + fireRate;  // ตั้งค่าหน่วงเวลาเพื่อป้องกันการยิงรัว
        }
    }

    void ShootFireball()
    {
        // สร้างกระสุนไฟที่ firePoint
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);

        // ให้ Rigidbody ของกระสุนไฟเคลื่อนที่ไปข้างหน้า
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * fireballSpeed;
        }
    }
}
