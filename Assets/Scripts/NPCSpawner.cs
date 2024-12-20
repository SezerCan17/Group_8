using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSpawnerNavMesh : MonoBehaviour
{
    public GameObject npcPrefab; // NPC prefab
    public NPCPatrol patrolPath; // NPC'lerin takip edeceði path
    public int numberOfNPCs = 5; // Spawn edilecek NPC sayýsý
    public float spawnRadius = 10f; // Spawn alanýnýn yarýçapý
    public Vector3 spawnCenter; // Spawn alanýnýn merkezi
    public float navMeshSampleDistance = 2f; // NavMesh üzerinde pozisyon bulma yarýçapý

    private List<GameObject> spawnedNPCs = new List<GameObject>();

    void Start()
    {
        SpawnNPCs();
    }

    void SpawnNPCs()
    {
        if (npcPrefab == null || patrolPath == null)
        {
            Debug.LogWarning("NPC Prefab veya Patrol Path atanmamýþ!");
            return;
        }

        for (int i = 0; i < numberOfNPCs; i++)
        {
            Vector3 randomPosition = GetRandomNavMeshPosition();
            if (randomPosition != Vector3.zero)
            {
                // NPC'yi oluþtur
                GameObject npc = Instantiate(npcPrefab, randomPosition, Quaternion.identity);

                // Patrol path'i NPC'ye ata
                NPCController npcController = npc.GetComponent<NPCController>();
                if (npcController != null)
                {
                    npcController.patrolPath = patrolPath;
                }

                // Listeye ekle
                spawnedNPCs.Add(npc);
            }
            else
            {
                Debug.LogWarning("Geçerli bir NavMesh pozisyonu bulunamadý.");
            }
        }
    }

    Vector3 GetRandomNavMeshPosition()
    {
        // Rastgele bir pozisyon seç
        Vector3 randomPosition = spawnCenter + Random.insideUnitSphere * spawnRadius;
        randomPosition.y = spawnCenter.y; // Yüksekliði sabitle

        // NavMesh üzerinde geçerli bir pozisyon bul
        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, navMeshSampleDistance, NavMesh.AllAreas))
        {
            return hit.position; // Geçerli bir NavMesh pozisyonu
        }

        return Vector3.zero; // Geçersiz pozisyon
    }
}
