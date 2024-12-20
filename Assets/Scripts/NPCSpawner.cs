using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSpawnerNavMesh : MonoBehaviour
{
    public GameObject npcPrefab; // NPC prefab
    public NPCPatrol patrolPath; // NPC'lerin takip edece�i path
    public int numberOfNPCs = 5; // Spawn edilecek NPC say�s�
    public float spawnRadius = 10f; // Spawn alan�n�n yar��ap�
    public Vector3 spawnCenter; // Spawn alan�n�n merkezi
    public float navMeshSampleDistance = 2f; // NavMesh �zerinde pozisyon bulma yar��ap�

    private List<GameObject> spawnedNPCs = new List<GameObject>();

    void Start()
    {
        SpawnNPCs();
    }

    void SpawnNPCs()
    {
        if (npcPrefab == null || patrolPath == null)
        {
            Debug.LogWarning("NPC Prefab veya Patrol Path atanmam��!");
            return;
        }

        for (int i = 0; i < numberOfNPCs; i++)
        {
            Vector3 randomPosition = GetRandomNavMeshPosition();
            if (randomPosition != Vector3.zero)
            {
                // NPC'yi olu�tur
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
                Debug.LogWarning("Ge�erli bir NavMesh pozisyonu bulunamad�.");
            }
        }
    }

    Vector3 GetRandomNavMeshPosition()
    {
        // Rastgele bir pozisyon se�
        Vector3 randomPosition = spawnCenter + Random.insideUnitSphere * spawnRadius;
        randomPosition.y = spawnCenter.y; // Y�ksekli�i sabitle

        // NavMesh �zerinde ge�erli bir pozisyon bul
        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, navMeshSampleDistance, NavMesh.AllAreas))
        {
            return hit.position; // Ge�erli bir NavMesh pozisyonu
        }

        return Vector3.zero; // Ge�ersiz pozisyon
    }
}
