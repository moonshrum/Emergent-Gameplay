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

            challengesAnnouncement.transform.Find("First Challenge").transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = firstChallengeText;
            challengesAnnouncement.transform.Find("Second Challenge").transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = secondChallengeText;

            challengesInTheShop.transform.Find("First Challenge").transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = firstChallengeText;
            challengesInTheShop.transform.Find("Second Challenge").transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = secondChallengeText;

            StartCoroutine(ChallengesAnnouncementCo(challengesAnnouncement));
        }
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
        /*if (ChallengesPerRound > AllChallanges.Count)
        {
            ChallengesPerRound = AllChallanges.Count;
        }*/
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
}
