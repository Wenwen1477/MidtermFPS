using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject impactEffect; // �Ϳ࿡�����Դ
    public int damage = 10; // ��Ҵ����

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // ��ҡ���ع���ѵ��
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // �Ӵ�����ѵ��
            }

            // ���ҧ�Ϳ࿡�����Դ���Ƿ���¡���ع
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

