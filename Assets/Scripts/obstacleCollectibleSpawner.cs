using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleCollectibleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform playerTransform; // Assign VR camera or head
    public Transform headTransform;
    public float spawnDistanceAhead = 30f;
    public float spawnIntervalZ = 10f;
    public float laneOffsetX = 2f;
    public int totalSpawnPoints = 50;

    private float obstacleYPosition = 0f;

    public GameObject gemPrefab;
    public float gemSpawnChance = 0.6f; 
    public float[] gemYOffsets = new float[] { -0.5f, 0f, 0.5f }; 
    private float playerHeadY = 1.6f; // default, will overwrite in Start()
    private List<Vector3> obstaclePositions = new List<Vector3>();


    void Start()
    {
        playerHeadY = headTransform.position.y;
        obstacleYPosition = playerHeadY;
        for (int i = 1; i <= totalSpawnPoints; i++)
        {
            float rowZ = i * spawnIntervalZ;
            SpawnObstacleRow(rowZ);

            // Add gem in between (50% chance)
            if (Random.value < 0.5f)
            {
                float midZ = rowZ - (spawnIntervalZ / 2f);
                TrySpawnGem(midZ);
            }
        }
    }

    void SpawnInitialObstacles()
    {
        for (int i = 1; i <= totalSpawnPoints; i++)
        {
            SpawnObstacleRow(i * spawnIntervalZ);
        }
    }

    void SpawnObstacleRow(float zPos)
    {
        int laneToBlock = Random.Range(0, 3);

        for (int lane = 0; lane < 3; lane++)
        {
            if (lane == laneToBlock)
            {
                Vector3 obstaclePos = new Vector3(GetLaneX(lane), obstacleYPosition, zPos);
                GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
                Instantiate(prefab, obstaclePos, Quaternion.identity);
                obstaclePositions.Add(obstaclePos); // record position
            }
        }

        TrySpawnGem(zPos);
    }

    void TrySpawnGem(float zPos)
    {
        if (Random.value > gemSpawnChance)
            return;

        int lane = Random.Range(0, 3);
        float x = GetLaneX(lane);

        Vector3 checkPos = new Vector3(x, obstacleYPosition, zPos);

        // Check if this lane & z already has an obstacle
        foreach (Vector3 pos in obstaclePositions)
        {
            if (Mathf.Approximately(pos.z, zPos) && Mathf.Approximately(pos.x, x))
                return; // Don't spawn gem here
        }

        // Choose random height offset: below, same, or above head
        float y = playerHeadY + gemYOffsets[Random.Range(0, gemYOffsets.Length)];

        Vector3 gemPos = new Vector3(x, y, zPos);
        Instantiate(gemPrefab, gemPos, Quaternion.identity);
    }


    float GetLaneX(int laneIndex)
    {
        switch (laneIndex)
        {
            case 0: return -laneOffsetX;
            case 1: return 0f;
            case 2: return laneOffsetX;
            default: return 0f;
        }
    }
}
