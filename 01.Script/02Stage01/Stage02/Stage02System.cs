using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage02System : MonoBehaviour
{

    public Stage0102Main stageMain;
    public AnimationClip infoAnim;
    public GameObject[] infoUi;
    public GameObject[] gameUi;
    public GameObject[] overUi;
    public Stage02SeatController[] stageSeatController;
    public Image fade;
    public int score00;
    public int score01;
    public int score02;
    public int score03;
    public Text scoreTxt00;
    public AudioSource mainBGM;
    public GameObject[] startUi;
    public Text scoreTxt01;
    public Text scoreTxt02;
    public Text scoreTxt03;
    public Text[] timer;
    public Image[] gauge;
    public HouseManager[] houseManager;
    private float amountVal;

    private int countDone;
    private bool animDone;
    private float sec;
    private bool timeOver;
    [HideInInspector] public int time;

    private void Start()
    {
        for (int i = 0; i < infoUi.Length; i++)
        {
            infoUi[i].SetActive(true);
            gameUi[i].SetActive(false);
            overUi[i].SetActive(false);
        }
        score00 = GameManager.score0;
        score01 = GameManager.score1;
        score02 = GameManager.score2;
        score03 = GameManager.score3;
        scoreTxt00.text = GameManager.score0.ToString();
        scoreTxt01.text = GameManager.score1.ToString();
        scoreTxt02.text = GameManager.score2.ToString();
        scoreTxt03.text = GameManager.score3.ToString();
        animDone = false;
        timeOver = false;
        StartCoroutine(AnimPlay());
        sec = 60;
        amountVal = 1;
    }

    private void Update()
    {
        if (animDone)
        {
            Timer();
            if (!timeOver)
            {
                amountVal -= 0.017f * Time.deltaTime;
                for(int i=0; i < gauge.Length; i++)
                {
                    gauge[i].fillAmount = amountVal;
                }
                score00 = GameManager.score0;
                score01 = GameManager.score1;
                score02 = GameManager.score2;
                score03 = GameManager.score3;
                scoreTxt00.text = GameManager.score0.ToString();
                scoreTxt01.text = GameManager.score1.ToString();
                scoreTxt02.text = GameManager.score2.ToString();
                scoreTxt03.text = GameManager.score3.ToString();
                for(int i=0; i < stageSeatController.Length; i++)
                {
                    stageSeatController[i].onPlay = true;
                    stageSeatController[i].gameObject.SetActive(true);
                    infoUi[i].SetActive(false);
                    gameUi[i].SetActive(true);
                }

            }
            else
            {
                for(int i=0; i < stageSeatController.Length; i++)
                {
                    stageSeatController[i].gameObject.SetActive(false);
                    stageSeatController[i].onPlay = false;
                }
                countDone++;
                if (countDone == 1)
                {
                    StartCoroutine(DonePlay());
                }
            }
        }
    }

    private void Timer()
    {
        if (!timeOver)
        {

            if (sec > 0)
            {

                sec -= Time.deltaTime;
                string timerstr = string.Format("{0:N0}", sec);
                for (int i = 0; i < timer.Length; i++)
                {
                    timer[i].text = timerstr;
                }
            }
            else
            {
                sec = 0;
                timeOver = true;
            }
            
        }
    }

    IEnumerator AnimPlay()
    {
        mainBGM.volume = 0.2f;
        yield return new WaitForSeconds(infoAnim.length);
        for(int i=0; i < startUi.Length; i++)
        {
            infoUi[i].SetActive(false);
            gameUi[i].SetActive(true);
            startUi[i].SetActive(true);
        }
        yield return new WaitForSeconds(4.5f);
        for(int i=0; i < startUi.Length; i++)
        {
            startUi[i].SetActive(false);
        }
        animDone = true;
        mainBGM.volume = 0.6f;
    }
    IEnumerator DonePlay()
    {
        for (int i = 0; i < houseManager.Length; i++)
        {
            houseManager[i].onPlay = false;
        }
        for (int i=0; i < overUi.Length; i++)
        {
            overUi[i].SetActive(true);
        }
        yield return new WaitForSeconds(5f);
        
        stageMain.infoPlay = true;
        for (int i = 0; i < infoUi.Length; i++)
        {
            infoUi[i].SetActive(false);
            gameUi[i].SetActive(false);
            overUi[i].SetActive(false);
        }
        yield return new WaitForSeconds(1f);
        //stageMain.gkameEnd = true;
    }

    
}
