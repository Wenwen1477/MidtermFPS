using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject impactEffect; // �Ϳ࿡�����Դ
    public int damage = 10; // ��Ҵ����

    void OnTriggerEnter(Collider other)
    {
        // ��Ǩ�ͺ�������͡���ع���Ѻ�ѵ�ط���� Tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // ���Ҥ���๹�� EnemyHealth ��ѵ��
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // �觴���������ѵ��
            }

            // ���ҧ�Ϳ࿡�����Դ
            GameObject effect = Instantiate(impactEffect, transform.position, Quaternion.identity);

            // ������Ϳ࿡����ѧ�ҡ 3 �Թҷ�
            Destroy(effect, 3f);

            // ź����ع
            Destroy(gameObject);
        }
    }
}

