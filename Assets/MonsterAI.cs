using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // ตรวจสอบว่า NavMeshAgent อยู่บน NavMesh หรือไม่
        if (agent.isOnNavMesh)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            Debug.LogError("MonsterAI: NavMeshAgent ไม่ได้อยู่บน NavMesh!");
        }
    }

    void Update()
    {
        if (player != null && agent.isOnNavMesh)
        {
            agent.SetDestination(player.position);

            void Start()
            {
                agent = GetComponent<NavMeshAgent>();

                if (agent.isOnNavMesh)
                {
                    player = GameObject.FindGameObjectWithTag("Player").transform;
                    Debug.Log("NavMeshAgent พร้อมใช้งาน!");
                }
                else
                {
                    Debug.LogError("NavMeshAgent ไม่ได้อยู่บน NavMesh! ตรวจสอบว่า Bake NavMesh แล้วหรือยัง?");
                }
            }

        }
    }
}
