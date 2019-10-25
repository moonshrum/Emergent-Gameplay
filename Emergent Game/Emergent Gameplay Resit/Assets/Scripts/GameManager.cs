﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Player> AllPlayers = new List<Player>();
    public p1_Camp Camp_1;
    public p2_Camp Camp_2;
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
        //spawn players after all players are confirmed in
        /*foreach (Player player in AllPlayers)
        {
            if (player.PlayerNumber == 1)
                player.transform.position = Camp_1.transform.position;
            else
                player.transform.position = Camp_2.transform.position;
        }*/
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
        /*if (!GameFinished())
        {
            BlueprintsManager.Instance.ReceiveBlueprint(player);
        }*/
        BlueprintsManager.Instance.ReceiveBlueprint(player);
    }
    public bool GameFinished()
    {
        bool gameFinished = false;
        foreach (Player player in AllPlayers)
        {
            if (player.UnlockedBlueprints >= BlueprintsManager.Instance.BlueprintsToCollect)
            {
                //TODO: End Game
                Debug.Log("Game Finished");
                gameFinished = true;
            }
        }
        return gameFinished;
    }
}
