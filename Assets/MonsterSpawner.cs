using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 3f;
    public float maxSpawnDistance = 3.0f; // ขยายระยะให้หา NavMesh ได้ง่ายขึ้น

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // หา NavMesh ที่ใกล้ที่สุด
            if (NavMesh.SamplePosition(spawnPoint.position, out NavMeshHit hit, maxSpawnDistance, NavMesh.AllAreas))
            {
                if (monsterPrefab != null)
                {
                    GameObject monster = Instantiate(monsterPrefab, hit.position, spawnPoint.rotation);

                    // ตรวจสอบ NavMeshAgent
                    NavMeshAgent agent = monster.GetComponent<NavMeshAgent>();
                    if (agent != null)
                    {
                        agent.enabled = false; // ปิดก่อนเพื่อป้องกันปัญหา
                        yield return null; // รอ 1 เฟรม
                        agent.enabled = true; // เปิดใหม่หลังจากเกิดมาแล้ว

                        agent.speed = 3.5f;
                        agent.angularSpeed = 120f;

                        // เริ่มเดินหลังจากรอให้ NavMeshAgent โหลดเสร็จ
                        yield return new WaitForSeconds(0.2f);

                        PlayerController playerController = FindObjectOfType<PlayerController>();
                        if (playerController != null)
                        {
                            agent.SetDestination(playerController.transform.position);
                        }
                        else
                        {
                            Debug.LogWarning("❌ ไม่พบ PlayerController ในฉาก!");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("❌ Monster Prefab ไม่มี NavMeshAgent!");
                    }
                }
                else
                {
                    Debug.LogError("❌ Monster Prefab ยังไม่ได้กำหนด!");
                }
            }
            else
            {
                Debug.LogWarning("❌ จุดเกิดมอนสเตอร์ไม่อยู่บน NavMesh หรือไกลเกินไป!");
            }
        }
    }
}
