using UnityEngine;

public class FireballShooter : MonoBehaviour
{
    public GameObject fireballPrefab;  // ������ҧ�ͧ����ع� (Prefab)
    public Transform firePoint;  // �ش����ԧ����ع��͡�
    public float fireballSpeed = 10f;  // �������Ǣͧ����ع�
    public float fireRate = 0.5f;  // ���˹�ǧ���������ҧ����ԧ���Ф���
    private float nextFireTime = 0f;  // ��ǨѺ��������Ѻ����ԧ

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            ShootFireball();
            nextFireTime = Time.time + fireRate;  // ��駤��˹�ǧ�������ͻ�ͧ�ѹ����ԧ���
        }
    }

    void ShootFireball()
    {
        // ���ҧ����ع俷�� firePoint
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);

        // ��� Rigidbody �ͧ����ع�����͹���仢�ҧ˹��
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * fireballSpeed;
        }
    }
}
