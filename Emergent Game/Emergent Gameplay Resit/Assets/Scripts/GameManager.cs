using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public readonly int BlueprintsToCollect = 5;
    public List<Player> AllPlayers = new List<Player>();
    private int RoundCounter = 1;


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
        StartCoroutine(GameStartedSequenceCo());
    }
    private IEnumerator GameStartedSequenceCo()
    {
        yield return new WaitForSeconds(1f);
        AnnounceRound();
        yield return new WaitForSeconds(4f);
        ChallengesManager.Instance.AnnounceNewChallenges();
    }
    private void AnnounceRound()
    {
        foreach (Player player in AllPlayers)
        {
            GameObject roundAnnouncement = player.RoundAnnouncement;
            roundAnnouncement.GetComponentInChildren<TextMeshProUGUI>().text = "Round " + RoundCounter.ToString();
            roundAnnouncement.SetActive(true);
            roundAnnouncement.GetComponent<RoundAnnouncement>().enabled = true;
        }
    }
    public void RoundFinished(Player player)
    {
        player.UnlockedBlueprints++;
        Debug.Log(player.UnlockedBlueprints + "Round Finished");
        //TODO: Animation for receiving the blueprint
        if (!GameFinished())
        {
            ChallengesManager.Instance.SelectRoundChallenges();
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
