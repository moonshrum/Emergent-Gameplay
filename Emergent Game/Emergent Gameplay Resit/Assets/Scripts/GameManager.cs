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

    [SerializeField] private Transform _camp1;
    [SerializeField] private Transform _camp2;

    public bool gameStarted;
    [System.NonSerialized]
    public int playersReady = 0;

    

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
        gameStarted = false;
        //spawn players after all players are confirmed in
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameStarted == false)
        {
            playersReady++;
        }
        if (playersReady == 2 && gameStarted == false)
        {
            gameStarted = true;
            foreach (Player player in AllPlayers)
            {
                player.transform.position = player.PlayerNumber == 1 ? _camp1.transform.position : _camp2.transform.position;

                if (player.PlayerNumber == 1)
                    player.Character1.SetActive(true);
                else
                    player.Character2.SetActive(true);
            }

            //SFX: loop day sounds
            StartCoroutine(GameStartedSequenceCo());
            StartCoroutine(DayNightCycle());
        }
        
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
