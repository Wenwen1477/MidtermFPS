using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 50; // เลือดของศัตรู

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + " ได้รับความเสียหาย: " + damage);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " ตายแล้ว!");
        Destroy(gameObject); // ทำลายศัตรู
    }
}
