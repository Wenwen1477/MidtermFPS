using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    private NavMeshAgent agent;  // ตัวควบคุมการเดิน
    private Transform player;    // เป้าหมาย (VRM Player)

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // ดึง NavMeshAgent จาก GameObject

        // หา GameObject ที่มี Tag เป็น "Player" (VRM Player)
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("ไม่พบ Player ที่มี Tag = 'Player'! ตรวจสอบใน Inspector ด้วย!");
        }
    }

    void Update()
    {
        if (player != null && agent != null && agent.isOnNavMesh)  // เช็คว่ามี Player และ Agent อยู่บน NavMesh
        {
            agent.SetDestination(player.position); // ให้มอนสเตอร์เดินไปหาผู้เล่น
        }
    }
}
