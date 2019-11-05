using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironementGenerator : MonoBehaviour
{
    public static EnvironementGenerator Instance;
    public GameObject Crab;
    public GameObject BigIron;
    public GameObject SmallIron;
    public GameObject LargeGold;
    public GameObject SmallGold;
    public GameObject Tree;
    public GameObject LargeBush;
    public GameObject SmallBush;
    public GameObject Bear;
    public GameObject LargeBerries;
    public GameObject SmallBerries;
    public GameObject LargePoison;
    public GameObject SmallPoison;


    int BearsToSpawn;
    int CrabsToSpawn;
    int BigIronsToSpawn;
    int SmallIronsToSpawn;
    int LargeGoldsToSpawn;
    int SmallGoldsToSpawn;
    int TreesToSpawn;
    int LargeBushesToSpawn;
    int SmallBushesToSpawn;
    int LargeBerriesToSpawn;
    int SmallBerriesToSpawn;
    int LargePoisonToSpawn;
    int SmallPoisonToSpawn;

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
        BearsToSpawn = Random.Range(3, 7);
        CrabsToSpawn = Random.Range(5, 15);
        BigIronsToSpawn = Random.Range(3, 7);
        SmallIronsToSpawn = Random.Range(5, 15);
        LargeGoldsToSpawn = Random.Range(3, 7);
        SmallGoldsToSpawn = Random.Range(5, 15);
        TreesToSpawn = Random.Range(10, 20);
        LargeBushesToSpawn = Random.Range(5, 10);
        SmallBushesToSpawn = Random.Range(10, 20);
        LargeBerriesToSpawn = Random.Range(5, 10);
        SmallBerriesToSpawn = Random.Range(10, 20);
        LargePoisonToSpawn = Random.Range(5, 10);
        SmallPoisonToSpawn = Random.Range(10, 20);

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        SpawnObjects(Bear, BearsToSpawn, 1, 1);
        SpawnObjects(Crab, CrabsToSpawn, 1, 1);
        SpawnObjects(BigIron, BigIronsToSpawn, 1, 1);
        SpawnObjects(SmallIron, SmallIronsToSpawn, 1, 1);
        SpawnObjects(LargeGold, LargeGoldsToSpawn, 1, 1);
        SpawnObjects(SmallGold, SmallGoldsToSpawn, 1, 1);
        SpawnObjects(Tree, TreesToSpawn, 1, 1);
        SpawnObjects(LargeBush, LargeBushesToSpawn, 1, 1);
        SpawnObjects(SmallBush, SmallBushesToSpawn, 1, 1);
        SpawnObjects(LargeBerries, LargeBerriesToSpawn, 1, 1);
        SpawnObjects(SmallBerries, SmallBerriesToSpawn, 1, 1);
        SpawnObjects(LargePoison, LargePoisonToSpawn, 1, 1);
        SpawnObjects(SmallPoison, SmallPoisonToSpawn, 1, 1);
    }
    public void SpawnObjects(GameObject itemToSpawn, int numberToSpawn, float minScale, float maxScale)
    {
        bool canMulti = true;
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
            if (_multiChance <= 10 && itemToSpawn != Bear && itemToSpawn != Crab && canMulti)
            {
                var multiAmount = Random.Range(2, 5);
                for (int m = 0; m < multiAmount; m++)
                {
                    newSpawn = Instantiate(itemToSpawn, spawnPos, Quaternion.identity) as GameObject;
                    randomSeed = Random.Range(minScale, maxScale);
                    newSpawn.transform.localScale = Vector2.one * randomSeed;
                    newSpawn.transform.position = Random.insideUnitCircle * 12;
                }
                canMulti = false;
            }
            else
            {
                newSpawn = Instantiate(itemToSpawn, spawnPos, Quaternion.identity) as GameObject;
                //randomSeed = Random.Range(minScale, maxScale);
                //newSpawn.transform.localScale = Vector2.one * randomSeed;
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

    /*public static bool OnDirt(Vector2 pos)
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
    }*/
}
