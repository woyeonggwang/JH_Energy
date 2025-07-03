using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour
{

    public Stage02SeatController stageSeatController;
    public Stage02System stageSystem;
    public int seatIndex;
    public AudioSource colliderSound;
    public HouseManager houseManager;
    private int getScoreCount;
    private bool catched;
    private bool lost;
    private int countPos;
    private void OnEnable()
    {
        catched = false;
        lost = false;
        getScoreCount = 2;
        transform.GetComponent<MeshRenderer>().enabled = true;
        transform.GetComponent<SphereCollider>().enabled = true;
    }
    private void Update()
    {
        if (transform.localPosition.y < -11)
        {
            countPos++;
            if (countPos == 1)
            {
                transform.GetComponent<MeshRenderer>().enabled = false;
                transform.GetComponent<SphereCollider>().enabled = false;
                gameObject.SetActive(false);
            }
        }
        getScoreCount++;
        if (getScoreCount == 1)
        {
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

    IEnumerator TakePlay()
    {
        //캐릭터가 담았을 때 발동되는 코루틴
        try
        {
            houseManager.targetObj.GetComponent<HouseController>().energy+=0.25f;

        }
        finally
        {

        }
        getScoreCount = 0;
        transform.GetComponent<MeshRenderer>().enabled = false;
        transform.GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    IEnumerator LostPlay()
    {
        transform.GetComponent<MeshRenderer>().enabled = false;
        transform.GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "dish")
        {
            colliderSound.Play();
            print(0);
            stageSeatController.scoreVal++;
            print(stageSeatController.score);
            catched = true;
            if (!lost)
            {
                StartCoroutine(TakePlay());
            }
        }
        if (other.gameObject.tag == "endpoint")
        {
            lost = true;

            if (!catched)
            {
                StartCoroutine(LostPlay());
            }
        }
    }

}
