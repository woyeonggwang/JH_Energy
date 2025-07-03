using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Stage0102Main : MonoBehaviour
{

    public float moveRange;
    public float charMoveRange;
    public float leftVal;
    public float rightVal;
    
    public Transform[] cameraPos;
    public float stage1PosY;
    public float stage2PosY;
    public float moveSpeed;
    public bool stage01Bool;
    public bool stage02Bool;
    public bool gameEnd;
    public AudioSource mainBGM;
    private int gameEndCount;
    public GameObject stage01System;
    public GameObject stage02System;
    public Image fade;
    public VideoPlayer vid00;
    public VideoPlayer vid01;
    public GameObject vidBG;
    private int infoCount;
    [HideInInspector]public bool infoPlay;
    private bool closer0;
    private bool closer1;
    private int stage2FadeCount;

    private void Start()
    {
        
        vid00.GetComponent<RawImage>().color = new Color(1, 1, 1, 0);
        vid01.GetComponent<RawImage>().color = new Color(1, 1, 1, 0);
        fade.color = new Color(0, 0, 0, 1);
        StartCoroutine(FadeIn());
        stage01System.SetActive(false);
        //stage1PosY = 371;
        //stage2PosY = -94f;
        for (int i = 0; i < cameraPos.Length; i++)
        {
            cameraPos[i].position = new Vector3(cameraPos[i].position.x, -94f, cameraPos[i].position.z);
        }
        stage01Bool = true;
        stage02Bool = false;
        closer0 = false;
        closer1 = false;
        gameEnd = false;
        gameEndCount = 0;
    }

    private void Update()
    {
       
        if (!gameEnd)
        {

            if (stage01Bool)
            {
                if (!infoPlay)
                {
                    infoCount = 0;
                    for (int i = 0; i < cameraPos.Length; i++)
                    {
                        if (!closer0)
                        {

                            if (stage1PosY > -94)
                            {
                                stage1PosY -= moveSpeed * Time.deltaTime;
                                closer0 = false;
                            }
                            else
                            {
                                stage1PosY = -94f;
                                closer0 = true;
                            }
                            //cameraPos[i].position = new Vector3(cameraPos[i].position.x, stage1PosY, cameraPos[i].position.z);
                        }
                        else
                        {
                            stage01System.SetActive(true);
                        }

                    }
                }
                else
                {
                    infoCount++;
                    if (infoCount == 1)
                    {
                        StartCoroutine(InfoPlay00());
                    }
                }
            }
            if (stage02Bool)
            {
                for (int i = 0; i < cameraPos.Length; i++)
                {
                    if (!infoPlay)
                    {
                        infoCount = 0;
                        //if (stage2PosY > -671f)
                        //{
                        //    stage2PosY -= moveSpeed * Time.deltaTime;
                        //    closer1 = false;
                        //}
                        //else
                        //{
                        //    stage2PosY = -671f;
                        //    closer1 = true;
                        //}
                        cameraPos[i].position = new Vector3(cameraPos[i].position.x, -671f, cameraPos[i].position.z);
                        stage02System.SetActive(true);
                        stage2FadeCount++;
                        if (stage2FadeCount == 1)
                        {
                            StartCoroutine(FadeIn());
                        }
                    }
                    else
                    {
                        infoCount++;
                        if (infoCount == 1)
                        {
                            
                            StartCoroutine(InfoPlay01());
                        }
                    }
                }
            }
        }
        else
        {
            gameEndCount++;
            if (gameEndCount == 1)
            {
                StartCoroutine(FadeOutSceneTrans());
            }
        }
    }

    

    IEnumerator FadeIn()
    {
        for (float i = 1; i > -0.1f; i -= 0.01f)
        {
            fade.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator InfoPlay00()
    {
        mainBGM.volume = 0.2f;
        vid00.Play();
        for(float i=0; i<1.1f; i += 0.01f)
        {
            vid00.GetComponent<RawImage>().color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(0.01f);
        }
        vidBG.SetActive(true);
        yield return new WaitForSeconds((float)vid00.clip.length-8f);
        for(float i=0f; i<1.1f; i += 0.01f)
        {
            fade.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }
        vidBG.SetActive(false);

        for (float i = 1; i > -0.1f; i -= 0.01f)
        {
            vid00.GetComponent<RawImage>().color = new Color(1, 1, 1, i);
        }

        mainBGM.volume = 0.6f;
        infoPlay = false;
        stage01Bool = false;
        stage02Bool = true;
    }
    IEnumerator InfoPlay01()
    {
       
        
        mainBGM.volume = 0.2f;
        vid01.Play();
        for(float i=0; i<1.1f; i += 0.01f)
        {
            vid01.GetComponent<RawImage>().color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(0.01f);
        }
        vidBG.SetActive(true);
        yield return new WaitForSeconds((float)vid01.clip.length-8f);
        for(float i=1; i>-0.1f; i -= 0.01f)
        {
            vid01.GetComponent<RawImage>().color = new Color(1, 1, 1, i);
        }
        vidBG.SetActive(false);
        mainBGM.volume = 0.6f;
        infoPlay = false;
        stage02Bool = false;
        gameEnd = true;
    }
    IEnumerator FadeOutSceneTrans()
    {
        for (float i = 0; i < 1.1f; i += 0.01f)
        {
            fade.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(4);
    }
}
