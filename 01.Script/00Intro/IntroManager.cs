using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class IntroManager : MonoBehaviour
{
    public AudioSource introBgm;
    public GameObject beforeUi; //클릭하기 전 ui
    public GameObject afterUi;
    public GameObject title;
    public AnimationClip anim;
    public AudioSource narration;
    private int player4BCount;
    private int count;
    private bool startBool;
    private bool end;
    private void Start()
    {
        narration.Stop();
        beforeUi.SetActive(true);
        afterUi.SetActive(false);
        startBool = false;
        title.SetActive(true);
        GameManager.score0 = 0;
        GameManager.score1 = 0;
        GameManager.score2 = 0;
        GameManager.score3 = 0;
        introBgm.volume = 0.8f;
        end = false;
    }
    private void Update()
    {
        if(Input.GetButtonDown("1P_B")||Input.GetButtonDown("2P_B")|| Input.GetButtonDown("3P_B")|| Input.GetButtonDown("4P_B") || Input.GetMouseButtonDown(0))
        {
            startBool = true;
            
        }
        //if(Input.GetAxisRaw("4P_B") == 1)
        //{
        //    player4BCount++;
        //    if(player4BCount==1)
        //    {
        //        startBool = true;
        //    }
        //}
        //else if (Input.GetAxisRaw("4P_B") == 0)
        //{
        //    player4BCount = 0;
        //}
        if (startBool)
        {
            if (introBgm.volume > 0.3f)
            {
                introBgm.volume -= 0.1f * Time.deltaTime;
            }
            count++;
            if (count == 1)
            {
                StartCoroutine(ClickPlay());
            }
            beforeUi.SetActive(false);
            afterUi.SetActive(true);
            title.SetActive(false);
        }
        if (end)
        {
            introBgm.volume -= 0.1f * Time.deltaTime;
        }
    }

    IEnumerator ClickPlay()
    {
        yield return new WaitForSeconds(1f);
        narration.Play();
        yield return new WaitForSeconds(anim.length);
        end = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
