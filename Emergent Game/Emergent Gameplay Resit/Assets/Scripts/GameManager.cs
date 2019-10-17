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
            ChallengesManager.Instance.AnnounceNewChallenges();
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
