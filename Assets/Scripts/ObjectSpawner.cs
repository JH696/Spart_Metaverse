using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class ObjectSpawner : MonoBehaviour
{
    public Transform target;    
    
    public GameObject axePrefab;              
    public GameObject knifePrefab;    
    public GameObject spearPrefab;
    public GameObject arrowPrefab;
    public GameObject heartPrefab;

    public float spawnOffset = 20f;          
    public float minY = -3f;
    public float maxY = 3f;
    public float spawnInterval = 1f;
    public float heartInterval = 30f;

    private float obstacleTimer = 0f;
    private float potionTimer = 0f;

    void Update()
    {
        if (target == null) return;

        obstacleTimer += Time.deltaTime;
        potionTimer += Time.deltaTime;

        if (obstacleTimer >= spawnInterval)
        {
            obstacleTimer = 0f;
            SpawnObstacle();

            spawnInterval -= spawnInterval * 0.01f;
        }

        if (potionTimer >= heartInterval)
        {
            potionTimer = 0f;
            SpawnPotion();
        }

    }
    void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3
        (target.position.x + spawnOffset,Random.Range(minY, maxY),0f);

        int prefab = Random.Range(1, 5);

        if (prefab == 1)
        {
            Instantiate(axePrefab, spawnPosition, Quaternion.identity);
        }
        else if (prefab == 2)
        {
            Instantiate(knifePrefab, spawnPosition, Quaternion.identity);
        }
        else if (prefab == 3)
        {
            Instantiate(spearPrefab, spawnPosition, spearPrefab.transform.rotation);
        }
        else if (prefab == 4)
        {
            Instantiate(arrowPrefab, spawnPosition, arrowPrefab.transform.rotation);
        }
    }
    void SpawnPotion()
    {
        Vector3 spawnPosition = new Vector3
        (target.position.x + spawnOffset, Random.Range(minY, maxY), 0f);

        Instantiate(heartPrefab, spawnPosition, Quaternion.identity);
    }
}
