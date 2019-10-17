using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChallengesManager : MonoBehaviour
{
    public static ChallengesManager Instance;
    [SerializeField]
    private List<Challenge> AllChallanges = new List<Challenge>();
    public List<Challenge> ThisRoundChallenges = new List<Challenge>();
    public readonly int ChallengesPerRound = 2;

    private int Challenge1ResourceCollected; // Counter to keep track of how much resources was picked up for the first challenge
    private int Challenge2ResourceCollected; // Counter to keep track of how much resources was picked up for the second challenge
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
    }
    private void Start()
    {
        SelectRoundChallenges();
    }
    public void AnnounceNewChallenges()
    {
        foreach (Player player in GameManager.Instance.AllPlayers)
        {
            GameObject challengesAnnouncement = player.ChallengesAnnouncement;
            GameObject challengesInTheShop = player.ChallengesInTheShop;
            string firstChallengeText = ThisRoundChallenges[0].TextToAnnounce;
            string secondChallengeText = ThisRoundChallenges[1].TextToAnnounce;
            string firstChallengeAmountText = ThisRoundChallenges[0].AmountCollected.ToString() + " / " + ThisRoundChallenges[0].AmountToCollectOrKill.ToString();
            string secondChallengeAmountText = ThisRoundChallenges[1].AmountCollected.ToString() + " / " + ThisRoundChallenges[1].AmountToCollectOrKill.ToString();
            Transform firstChallengeAnnouncement = challengesAnnouncement.transform.Find("First Challenge").transform;
            Transform secondChallengeAnnouncement = challengesAnnouncement.transform.Find("Second Challenge").transform;
            Transform firstShopChallenge = challengesInTheShop.transform.Find("First Challenge").transform;
            Transform secondShopChallenge = challengesInTheShop.transform.Find("Second Challenge").transform;

            firstChallengeAnnouncement.GetChild(1).GetComponent<TextMeshProUGUI>().text = firstChallengeText;
            secondChallengeAnnouncement.GetChild(1).GetComponent<TextMeshProUGUI>().text = secondChallengeText;

            firstShopChallenge.Find("Challenge Task").GetComponent<TextMeshProUGUI>().text = firstChallengeText;
            secondShopChallenge.Find("Challenge Task").GetComponent<TextMeshProUGUI>().text = secondChallengeText;

            firstShopChallenge.Find("Amount Text").GetComponent<TextMeshProUGUI>().text = firstChallengeAmountText;
            secondShopChallenge.Find("Amount Text").GetComponent<TextMeshProUGUI>().text = secondChallengeAmountText;

            StartCoroutine(ChallengesAnnouncementCo(challengesAnnouncement));
        }
    }
    private void UpdateShopChallenges()
    {

    }
    private IEnumerator ChallengesAnnouncementCo(GameObject challengesAnnouncement)
    {
        Animator animator = challengesAnnouncement.GetComponent<Animator>();
        animator.SetBool("Announce", true);
        yield return new WaitForSeconds(3f);
        animator.SetBool("Announce", false);
    }
    public void SelectRoundChallenges()
    {
        ThisRoundChallenges.Clear();
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
                    randomNumber = Random.Range(0, AllChallanges.Count);
                }
            }
            else
            {
                randomNumber = 0;
            }
            ThisRoundChallenges.Add(AllChallanges[randomNumber]);
            AllChallanges.Remove(AllChallanges[randomNumber]);
        }
        AllChallanges.Clear();
        AllChallanges = TempList;
    }
    public void IncreaseChallengeResource(Resource.ResourceType type, int amount, Player player)
    {
        foreach (Challenge challenge in ThisRoundChallenges)
        {
            if (challenge.TypeToCollect == type)
            {
                challenge.AmountCollected += amount;
            }
        }
        if (CheckIfChallengeIsComplete(type))
        {
            GameManager.Instance.RoundFinished(player);
        }
    }
    public bool CheckIfChallengeIsComplete(Resource.ResourceType type)
    {
        bool challengeCompleted = false;
        foreach (Challenge challenge in ThisRoundChallenges)
        {
            if (challenge.TypeToCollect == type)
            {
                if (challenge.AmountCollected >= challenge.AmountToCollectOrKill)
                {
                    challengeCompleted = true;
                    break;
                }
            }
        }
        return challengeCompleted;
    }
}
