using UnityEngine;

public class FireballShooter : MonoBehaviour
{
    public GameObject fireballPrefab; // ��� Prefab �ͧ����ع
    public Transform firePoint; // �ش������ع�Դ
    public float fireballSpeed = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // ����ԡ���������ԧ
        {
            ShootFireball();
        }
    }

    void ShootFireball()
    {
        // ���ҧ����ع
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);

        // �ѹ����ع仢�ҧ˹�Ҵ��� Rigidbody
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * fireballSpeed;
        }

        // ?? ź����ع��ѧ�ҡ 3 �Թҷ� ??
        Destroy(fireball, 3f);
    }
}
