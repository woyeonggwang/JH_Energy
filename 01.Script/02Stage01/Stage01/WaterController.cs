using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterController : MonoBehaviour
{
    public bool canSee;
    public Stage01System stageSystem;
    public Stage01SeatController stageSeatController;
    public int count;
    public int ran;
    public ParticleSystem[] energyParticle;
    [HideInInspector] public bool falling;
    [HideInInspector] public bool enable;
    public Image countTextImage;
    public Image waterImage;
    public Sprite energySpr;
    public Sprite[] countTextSpr;
    public AudioSource countDoneSound;
    public GameObject[] lostImage;
    public GameObject[] energyImage;
    public int seatIndex;
    public int lineIndex;
    public bool selected;
    public AudioSource lostSound;
    public AudioSource energySound;
    private bool lost;
    private int disactiveCount;
    private int countTargetNull;
    private void OnEnable()
    {
        canSee = false;
        countTextImage.sprite = countTextSpr[count];
        enable = true;
        falling = true;
        stageSeatController.objExistCount++;
        //stageSeatController.enableSeat[seatIndex] = false;
    }

    private void OnDisable()
    {
        stageSeatController.objExistCount--;
    }


    private void Update()
    {
        
        if (enable)
        {
            if (falling)
            {
                if (count > 0)
                {
                    lost = true;
                    countTextImage.sprite = countTextSpr[count];

                    if (lineIndex == stageSeatController.selectIndex)
                    {
                        selected = true;
                    }
                    else
                    {
                        selected = false;
                    }
                    
                    //stageSeatController.enableSeat[seatIndex] = false;
                }
                else
                {
                    lost = false;
                    countTextImage.gameObject.SetActive(false);
                    waterImage.sprite = energySpr;
                    transform.GetComponent<Rigidbody2D>().gravityScale =50;
                    countTargetNull++;
                    if (countTargetNull == 1)
                    {
                        countDoneSound.gameObject.SetActive(true);
                        switch (seatIndex)
                        {
                            case 0:
                                GameManager.score0++;
                                break;
                            case 1:
                                GameManager.score1++;

                                break;
                            case 2:
                                GameManager.score2++;

                                break;
                            case 3:
                                GameManager.score3++;

                                break;
                        }
                    }
                }
            }
            else
            {
                disactiveCount++;
                if (disactiveCount == 1)
                {
                    StartCoroutine(DisactivePlay());
                }
            }
        }
        else
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "endpoint")
        {
            falling = false;
            StartCoroutine(EndPlay());
        }
        if (other.gameObject.tag == "line")
        {
            selected = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "line")
        {

        }
        if (other.gameObject.tag == "mask")
        {
            canSee = true;
            print("mask");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //if (other.gameObject.tag == "line")
        //{

        //    selected = false;
        //}
        
    }

    IEnumerator EndPlay()
    {
        if (lost)
        {
            lostSound.Play();
        }
        else
        {
            energyParticle[lineIndex].Play();
            energySound.Play();
        }
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator DisactivePlay()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
