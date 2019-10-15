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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(gameObject);
        }
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
}
