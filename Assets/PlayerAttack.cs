using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 20;
    public LayerMask enemyLayer; // กำหนดให้ตรวจจับเฉพาะศัตรู

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // คลิกซ้ายเพื่อโจมตี
        {
            Attack();
        }
    }

    void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10f, enemyLayer))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
            }
        }
    }
}
