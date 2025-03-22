using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab; // ตัวมอนสเตอร์ที่ต้องการให้เกิด
    public Transform[] spawnPoints; // จุดที่มอนสเตอร์เกิด
    public float spawnInterval = 3f; // เวลาที่มอนสเตอร์จะเกิดใหม่ (วินาที)

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true) // ให้เกิดมอนสเตอร์เรื่อยๆ
        {
            yield return new WaitForSeconds(spawnInterval); // รอเวลาที่กำหนด

            // เลือกจุดเกิดแบบสุ่ม
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // สร้างมอนสเตอร์ที่จุดเกิด
            Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
