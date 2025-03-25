using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("ไม่พบ GameObject ที่มี Tag 'Player'");
        }

        // ตรวจสอบว่า agent อยู่บน NavMesh หรือไม่
        if (agent == null || !agent.isOnNavMesh)
        {
            Debug.LogError("NavMeshAgent ไม่ได้อยู่บน NavMesh!");
        }
    }

    void Update()
    {
        if (agent != null && agent.isOnNavMesh && player != null)
        {
            if (agent.isActiveAndEnabled) // ป้องกันข้อผิดพลาดถ้า agent ถูกปิด
            {
                agent.SetDestination(player.position);
            }
        }
        else
        {
            Debug.LogWarning("MonsterAI ไม่อยู่บน NavMesh หรือไม่มี Player!");
        }
    }
}
