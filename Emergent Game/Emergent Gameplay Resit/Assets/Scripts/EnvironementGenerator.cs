using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironementGenerator : MonoBehaviour
{
    public static EnvironementGenerator Instance;
    public GameObject Enemy;
    public GameObject Rock;
    public GameObject Tree;
    public GameObject Bush;

    int EnemiesToSpawn = Random.Range(3, 7);
    int RocksToSpawn = Random.Range(5, 15);
    int TreesToSpawn = Random.Range(10, 20);
    int BushesToSpawn = Random.Range(10, 20);

    public Collider2D[] Colliders;
    public float Radius;
    public Collider2D MapCollider;
    public Collider2D DirtCollider;
    public Collider2D GrassCollider;
    [System.NonSerialized]
    public List<GameObject> PlacedRiverPieces = new List<GameObject>();

    private int _multiChance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        SpawnObjects(Enemy, EnemiesToSpawn, 1, 1);
        SpawnObjects(Rock, RocksToSpawn, 1, 4);
        SpawnObjects(Bush, BushesToSpawn, 1, 2);
        SpawnObjects(Tree, TreesToSpawn, 4, 8);
    }
    public void SpawnObjects(GameObject itemToSpawn, int numberToSpawn, float minScale, float maxScale)
    {
        /*if (itemToSpawn == Bush || itemToSpawn == Tree)
            MapCollider = GrassCollider;
        else
            MapCollider = DirtCollider;*/
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
            GameObject newSpawn;
            float randomSeed;

            while (!canSpawnHere)
            {
                float spawnPosX = Random.Range(leftExtent, rightExtent);
                float spawnPosY = Random.Range(lowerExtent, upperExtent);
                spawnPos = new Vector3(spawnPosX, spawnPosY, 0);

                spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
                canSpawnHere = PreventSpawnOverlap(spawnPos);
                /*if (itemToSpawn == Bush || itemToSpawn == Tree)
                    canSpawnHere = OnGrass(spawnPos);
                else
                    canSpawnHere = OnDirt(spawnPos);*/

                if (canSpawnHere)
                {
                    break;
                }

                safetyNet++;

                if (safetyNet > 50)
                {
                    //Debug.Log("Too many attempts.");
                    break;
                }
            }
            _multiChance = Random.Range(1, 100);
            if (_multiChance <= 10)
            {
                var multiAmount = Random.Range(2, 5);
                for (int m = 0; m < multiAmount; m++)
                {
                    newSpawn = Instantiate(itemToSpawn, spawnPos, Quaternion.identity) as GameObject;
                    randomSeed = Random.Range(minScale, maxScale);
                    newSpawn.transform.localScale = Vector2.one * randomSeed;
                    newSpawn.transform.position = Random.insideUnitCircle * 3;
                }
            }
            else
            {
                newSpawn = Instantiate(itemToSpawn, spawnPos, Quaternion.identity) as GameObject;
                randomSeed = Random.Range(minScale, maxScale);
                newSpawn.transform.localScale = Vector2.one * randomSeed;
            }            
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

    public static bool OnDirt(Vector2 pos)
    {
            Collider2D[] hits = Physics2D.OverlapCircleAll(pos, 0);
            foreach (Collider2D hit in hits)
            {
                if (hit.gameObject.layer == 13)
                {
                    return true;
                }
            }
            return false;        
    }
    public static bool OnGrass(Vector2 pos)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(pos, 0);
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.layer == 14)
            {
                return true;
            }
        }
        return false;
    }
}
