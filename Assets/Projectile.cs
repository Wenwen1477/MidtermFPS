using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 20; // ��ѧ���բͧ����ع
    public float speed = 10f;
    public float lifetime = 3f; // ����ع��������ѧ�ҡ 3 �Թҷ�

    void Start()
    {
        Destroy(gameObject, lifetime); // ź����ع�ѵ��ѵ���ѧ�ҡ�������ҷ���˹�
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // ��Ǩ�Ѻ੾���ѵ��
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject); // ����¡���ع��ѧ�ҡ��
        }
        else if (!other.CompareTag("Player") && !other.CompareTag("Projectile"))
        {
            Destroy(gameObject); // ����¡���ع����ͪ��ѵ����蹷������������
        }
    }
}

