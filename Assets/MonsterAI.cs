using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MonsterAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    public float stoppingDistance = 2.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // ค้นหา Player
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("❌ ไม่พบ GameObject ที่มี Tag 'Player'");
            return;
        }

        // เรียกให้ตัวมอนสเตอร์ไปอยู่บน NavMesh ถ้ายังไม่อยู่
        StartCoroutine(PlaceOnNavMesh());
    }

    void Update()
    {
        if (agent == null || player == null) return; // ถ้าไม่มี agent หรือ player ให้ข้ามไปเลย

        if (!agent.isOnNavMesh) return; // ถ้า agent ไม่ได้อยู่บน NavMesh ให้ข้ามไปเลย

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stoppingDistance)
        {
            agent.SetDestination(player.position); // ✅ ถ้า agent อยู่บน NavMesh ก็ให้เดิน
            animator.SetBool("isWalking", true);
        }
        else
        {
            agent.ResetPath();
            animator.SetBool("isWalking", false);
        }
    }

    IEnumerator PlaceOnNavMesh()
    {
        yield return new WaitForSeconds(0.5f); // หน่วงเวลาให้ NavMesh โหลดเสร็จ

        if (agent == null) yield break; // ถ้าไม่มี NavMeshAgent ให้จบฟังก์ชัน

        if (!agent.isOnNavMesh)
        {
            if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 5.0f, NavMesh.AllAreas))
            {
                Debug.Log("✅ Monster ถูกย้ายไปที่ NavMesh แล้ว!");
                agent.Warp(hit.position); // ย้ายตัวละครไปที่ตำแหน่งที่อยู่บน NavMesh
            }
            else
            {
                Debug.LogError("❌ ไม่พบพื้นที่ NavMesh ที่ใกล้ที่สุด!");
            }
        }

        agent.enabled = false;
        agent.enabled = true; // รีเซ็ต NavMeshAgent
    }
}
