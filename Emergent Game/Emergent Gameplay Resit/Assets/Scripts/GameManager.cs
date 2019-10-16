using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public readonly int BlueprintsToCollect = 5;
    [SerializeField]
    private List<Challenge> AllChallanges = new List<Challenge>();
    public List<Challenge> ThisRoundChallenges = new List<Challenge>();
    public int ChallengesPerRound;
    public List<Player> AllPlayers = new List<Player>();


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
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(gameObject);
        }

        SpawnObjects(Enemy, EnemiesToSpawn);
        SpawnObjects(Rock, RocksToSpawn);
        SpawnObjects(Bush, BushesToSpawn);
    }
    private void Start()
    {
        SelectRoundChallenges();
    }
    public void SelectRoundChallenges()
    {
        ThisRoundChallenges.Clear();
        if (ChallengesPerRound > AllChallanges.Count)
        {
            ChallengesPerRound = AllChallanges.Count;
        }
        List<Challenge> TempList = new List<Challenge>();
        for (int i = 0; i < AllChallanges.Count; i++)
        {
            TempList.Add(AllChallanges[i]);
        }
        for (int i = 0; i < ChallengesPerRound; i++)
        {
            int randomNumber = Random.Range(0, AllChallanges.Count);
            if (AllChallanges.Count > 1)
            {
                while (ThisRoundChallenges.Contains(AllChallanges[randomNumber]))
                {
                    randomNumber = Random.Range(0, ChallengesPerRound);
                }
            } else
            {
                randomNumber = 0;
            }
            ThisRoundChallenges.Add(AllChallanges[randomNumber]);
            AllChallanges.Remove(AllChallanges[randomNumber]);
        }
        AllChallanges.Clear();
        AllChallanges = TempList;
    }

    private void AnnounceNewChallenges()
    {
        foreach (Player player in AllPlayers)
        {
            //
        }
    }

    public void RoundFinished(Player player)
    {
        player.UnlockedBlueprints++;
        Debug.Log(player.UnlockedBlueprints + "Round Finished");
        //TODO: Animation for receiving the blueprint
        if (!GameFinished())
        {
            SelectRoundChallenges();
        }
    }
    public bool GameFinished()
    {
        foreach (Player player in AllPlayers)
        {
            if (player.UnlockedBlueprints >= BlueprintsToCollect)
            {
                //TODO: End Game
                Debug.Log("Game Finished");
            }
        }
        return false;
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
            Vector3 spawnPos = new Vector3(0,0,0);
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
