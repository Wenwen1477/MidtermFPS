using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab; // ����͹��������ͧ�������Դ
    public Transform[] spawnPoints; // �ش����͹������Դ
    public float spawnInterval = 3f; // ���ҷ���͹�������Դ���� (�Թҷ�)

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true) // ����Դ�͹������������
        {
            yield return new WaitForSeconds(spawnInterval); // �����ҷ���˹�

            // ���͡�ش�ԴẺ����
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // ���ҧ�͹�������ش�Դ
            Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
