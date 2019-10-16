using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironementGenerator : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Rock;
    public GameObject Tree;
    public GameObject Bush;

    public int EnemiesToSpawn;
    public int RocksToSpawn;
    public int TreesToSpawn;
    public int BushesToSpawn;

    public Collider2D[] Colliders;
    public float Radius;
    public Collider2D MapCollider;

    private void Awake()
    {
        SpawnObjects(Enemy, EnemiesToSpawn);
        SpawnObjects(Rock, RocksToSpawn);
        SpawnObjects(Bush, BushesToSpawn);
    }
    public void SpawnObjects(GameObject itemToSpawn, int numberToSpawn)
    {
        Vector3 centerPoint = MapCollider.bounds.center;
        float width = MapCollider.bounds.extents.x;
        float height = MapCollider.bounds.extents.y;

        float leftExtent = centerPoint.x - width;
        float rightExtent = centerPoint.x + width;
        float lowerExtent = centerPoint.y - height;
        float upperExtent = centerPoint.y + height;

        for (int i = 0; i < numberToSpawn; i++)
        {
            Vector3 spawnPos = new Vector3(0, 0, 0);
            bool canSpawnHere = false;
            int safetyNet = 0;


            while (!canSpawnHere)
            {
                float spawnPosX = Random.Range(leftExtent, rightExtent);
                float spawnPosY = Random.Range(lowerExtent, upperExtent);
                spawnPos = new Vector3(spawnPosX, spawnPosY, 0);

                spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
                canSpawnHere = PreventSpawnOverlap(spawnPos);

                if (canSpawnHere)
                {
                    break;
                }

                safetyNet++;

                if (safetyNet > 50)
                {
                    Debug.Log("Too many attempts.");
                    break;
                }
            }
            GameObject newSpawn = Instantiate(itemToSpawn, spawnPos, Quaternion.identity) as GameObject;
        }
    }

    bool PreventSpawnOverlap(Vector3 spawnPos)
    {
        Colliders = Physics2D.OverlapCircleAll(transform.position, Radius);

        foreach (var t in Colliders)
        {
            Vector3 centerPoint = t.bounds.center;
            float width = t.bounds.extents.x;
            float height = t.bounds.extents.y;

            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;

            if (!(spawnPos.x >= leftExtent) || !(spawnPos.x <= rightExtent)) continue;
            if (spawnPos.y >= lowerExtent && spawnPos.y <= upperExtent)
            {
                return false;
            }
        }
        return true;
    }
}
