using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Stage00Manager : MonoBehaviour
{
    public GameObject[] infoUi;
    public GameObject[] playUi;
    public GameObject[] overUi;
    public GameObject[] timerUi;
    public GameObject[] startUi;
    public GameObject vidBG;
    public Image fade;
    public VideoPlayer infoVid;
    public AnimationClip introAnimClip;
    public Image[] gauge;
    public Text score0;
    public Text score1;
    public Text score2;
    public Text score3;
    public Text[] timer;
    public SeatManager[] stageSeatController;
    public float moveSpeed;
    
    private bool timeOver;
    private float sec;
    private float amountVal;
    private bool canStart;
    private bool animDone;
    private int countDone;
    private void Start()
    {
        
        infoVid.gameObject.SetActive(false);
        fade.color = new Color(0, 0, 0, 1);
        for(int i=0; i < infoUi.Length; i++)
        {
            infoUi[i].SetActive(true);
            playUi[i].SetActive(false);
            timerUi[i].SetActive(false);
        }
        score0.text = GameManager.score0.ToString();
        score1.text = GameManager.score1.ToString();
        score2.text = GameManager.score2.ToString();
        score3.text = GameManager.score3.ToString();
        timeOver = false;
        sec = 40;
        amountVal = 1;
        animDone = false;
        StartCoroutine(StartDelay());
    }

    private void Update()
    {
      
        if (animDone)
        {
            Timer();
            if (!timeOver)
            {
                amountVal -= 0.025f * Time.deltaTime;
                for (int i = 0; i < gauge.Length; i++)
                {
                    gauge[i].fillAmount = amountVal;
                }
                for (int i = 0; i < stageSeatController.Length; i++)
                {
                    stageSeatController[i].onPlay = true;
                    stageSeatController[i].gameObject.SetActive(true);
                    
                }
                score0.text = GameManager.score0.ToString();
                score1.text = GameManager.score1.ToString();
                score2.text = GameManager.score2.ToString();
                score3.text = GameManager.score3.ToString();
            }
            else
            {
                for(int i=0; i<stageSeatController.Length;i++)
                {
                    stageSeatController[i].onPlay = false;
                    stageSeatController[i].gameObject.SetActive(false);
                }
                countDone++;
                if (countDone == 1)
                {
                    StartCoroutine(DonePlay());
                }
            }
        }
    }

    IEnumerator DonePlay()
    {
        for (int i = 0; i < overUi.Length; i++)
        {
            overUi[i].SetActive(true);
        }
        yield return new WaitForSeconds(5f);
        for(int i=0; i < overUi.Length; i++)
        {
            overUi[i].SetActive(false);
        }
        infoVid.gameObject.SetActive(true);
        vidBG.SetActive(true);
        infoVid.Play();
        for(float i=0; i<1.1f; i += 0.02f)
        {
            infoVid.GetComponent<RawImage>().color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds((float)infoVid.clip.length-8);

        for(float i=0; i<1.1f; i += 0.01f)
        {
            fade.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }

    IEnumerator StartDelay()
    {
        for(float i=1; i>-0.1f; i -= 0.01f)
        {
            fade.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(introAnimClip.length);
        for(int i=0; i < startUi.Length; i++)
        {
            startUi[i].SetActive(true);
            infoUi[i].SetActive(false);
            print("111111111");
        }
        yield return new WaitForSeconds(4.5f);
        
        for (int i=0; i < startUi.Length; i++)
        {
            startUi[i].SetActive(false);
            playUi[i].SetActive(true);
            print("0000000");
        }
        animDone = true;
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
}
