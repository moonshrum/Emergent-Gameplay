using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Player> AllPlayers = new List<Player>();
    private int RoundCounter = 1;

    public bool isNight = false;
    public SpriteRenderer NightSprite;

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
        //SFX: loop day sounds
        StartCoroutine(GameStartedSequenceCo());
        StartCoroutine(DayNightCycle());
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

    private IEnumerator DayNightCycle()
    {
        while (true)
        {            
            if (isNight == true)
            {
                StartCoroutine(SwapDayNight());
                isNight = false;
                //SFX: loop day sounds
            }
            else
            {
                StartCoroutine(SwapNightDay());
                isNight = true;
                //SFX: loop night sounds
            }
            yield return new WaitForSeconds(180f);
        }       
    }

    private IEnumerator SwapDayNight()
    {
        var i = 0.0f;
        var rate = 1.0f / 3;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            NightSprite.color = Color.Lerp(new Color(1f, 1f, 1f, 0.6f), new Color(1f, 1f, 1f, 0f), i);
            yield return null;
        }
    }

    private IEnumerator SwapNightDay()
    {
        var i = 0.0f;
        var rate = 1.0f / 3;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            NightSprite.color = Color.Lerp(new Color(1f, 1f, 1f, 0f), new Color(1f, 1f, 1f, 0.6f), i);
            yield return null;
        }
    }
}
