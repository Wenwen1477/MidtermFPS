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
            Debug.LogError("��辺 GameObject ����� Tag 'Player'");
        }

        // ��Ǩ�ͺ��� agent ���躹 NavMesh �������
        if (agent == null || !agent.isOnNavMesh)
        {
            Debug.LogError("NavMeshAgent ��������躹 NavMesh!");
        }
    }

    void Update()
    {
        if (agent != null && agent.isOnNavMesh && player != null)
        {
            if (agent.isActiveAndEnabled) // ��ͧ�ѹ��ͼԴ��Ҵ��� agent �١�Դ
            {
                agent.SetDestination(player.position);
            }
        }
        else
        {
            Debug.LogWarning("MonsterAI ������躹 NavMesh ��������� Player!");
        }
    }
}
