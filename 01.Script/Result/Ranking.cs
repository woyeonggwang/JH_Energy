using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{

    public SeatCheckScore[] seatCheckScore;
    public bool rankingDone;
    public Text[] scoreTxt;
    public GameObject rankingUi;
    public GameObject gaugeSound;
    public AudioSource mainBGM;
    public AudioSource rankingSound;
    public List<int> score = new List<int>();
    public List<int> orderScore = new List<int>();
    public ParticleSystem completeParticle;
    public int[] orderIndex = new int[4];
    public List<PlayerData> playerDatas = new List<PlayerData>();
    private int score0 = 5;
    private int score1 = 5;
    private int score2 = 8;
    private int score3 = 5;
    

    private void Start()
    {
        rankingDone = false;
        rankingUi.SetActive(false);
        //GameManager.score0 = 5;
        //GameManager.score1 = 5;
        //GameManager.score2 = 8;
        //GameManager.score3 = 5;


        score.Add(GameManager.score0);
        score.Add(GameManager.score1);
        score.Add(GameManager.score2);
        score.Add(GameManager.score3);
        //score.Add(score0);
        //score.Add(score1);
        //score.Add(score2);
        //score.Add(score3);
        orderScore = score.OrderByDescending(score => score).ToList<int>();
        seatCheckScore[0].score = GameManager.score0;
        seatCheckScore[1].score = GameManager.score1;
        seatCheckScore[2].score = GameManager.score2;
        seatCheckScore[3].score = GameManager.score3;
        //seatCheckScore[0].score = score0;
        //seatCheckScore[1].score = score1;
        //seatCheckScore[2].score = score2;
        //seatCheckScore[3].score = score3;
        seatCheckScore[0].max = orderScore[0];
        seatCheckScore[1].max = orderScore[0];
        seatCheckScore[2].max = orderScore[0];
        seatCheckScore[3].max = orderScore[0];


        
        StartCoroutine(RankingPlay());
        playerDatas.Sort(SortByScore);
        playerDatas.Reverse();
        CalHighScore();
        playerDatas[0].playerRank = 0;
        for (int i = 1; i < 4; i++)
        {
            if (playerDatas[i].playerScore.CompareTo(playerDatas[i - 1].playerScore) == -1) // i등이 i - 1등보다 점수가 낮음
            {
                playerDatas[i].playerRank = i;
            }
            else if (playerDatas[i].playerScore.CompareTo(playerDatas[i - 1].playerScore) == 0) //  i 등과 i -1등이 동점
            {
                playerDatas[i].playerRank = playerDatas[i - 1].playerRank;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(playerDatas[i].playerRank + 1 + "등     " + playerDatas[i].playerName + "     " + playerDatas[i].playerScore + "점");
        }
    }

    private void Update()
    {
        if (rankingDone)
        {
            gaugeSound.SetActive(false);
        }
        
        playerDatas.Sort(SortByScore);
        playerDatas.Reverse();
        CalHighScore();
        playerDatas[0].playerRank = 0;
        for (int i = 1; i < 4; i++)
        {
            if (playerDatas[i].playerScore.CompareTo(playerDatas[i - 1].playerScore) == -1) // i등이 i - 1등보다 점수가 낮음
            {
                playerDatas[i].playerRank = i;
            }
            else if (playerDatas[i].playerScore.CompareTo(playerDatas[i - 1].playerScore) == 0) //  i 등과 i -1등이 동점
            {
                playerDatas[i].playerRank = playerDatas[i - 1].playerRank;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(playerDatas[i].playerRank + 1 + "등     " + playerDatas[i].playerName + "     " + playerDatas[i].playerScore + "점");
        }


    }

    IEnumerator RankingPlay()
    {
        yield return new WaitForSeconds(32f);
        yield return new WaitForSeconds(5f);
        gaugeSound.SetActive(true);
        completeParticle.Play();
        rankingUi.SetActive(true);
        mainBGM.Stop();
        rankingSound.Play();
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene(0);
    }
    private string CalHighScore()
    {
        int highScore = 0;
        string topChar = "";

        for (int i = 0; i < 3; i++)
        {
            if (playerDatas[i].playerScore > highScore)
            {
                highScore = playerDatas[i].playerScore;
                topChar = playerDatas[i].playerName;
            }
        }
        return topChar;
    }

    private int GetPlayerScore(PlayerData _playerData)
    {
        return _playerData.playerScore;
    }

    private int SortByScore(PlayerData _playerA, PlayerData _playerB)
    {
        return _playerA.playerScore.CompareTo(_playerB.playerScore);
    }

}
