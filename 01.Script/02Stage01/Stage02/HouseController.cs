using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseController : MonoBehaviour
{

    public HouseManager houseManager;
    public int type;
    public int index;
    public int seatGetIndex;
    public int seatNum;
    public int lineIndex;
    public bool select;
    public float moveSpeed;
   
    public Transform[] targetPos;
    public Transform endPos;
    public bool canMove;
    public bool clicked;
    public bool selected;
    public bool catched;
    public bool lost;
    public bool done;
    public float energy;
    public GameObject gaugeImage;
    private int moveDelayCount;
    private int catchCount;
    private void Start()
    {
        canMove = true;
        selected = false;
        lost = false;
        gaugeImage = transform.GetChild(0).gameObject;
        transform.localScale = new Vector3(1, 1, 1);
        //transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
    }

    private void Update()
    {
        
        print(index);
        if (!lost)
        {

            if (!catched)
            {
                if (index < 3)
                {
                    houseManager.lineObj[index] = gameObject;
                }
                if (index ==1 && houseManager.targetObj == null)
                {
                    houseManager.targetObj = gameObject;
                }
                if (gameObject == houseManager.targetObj)
                {
                    gaugeImage.SetActive(true);
                    gaugeImage.GetComponent<Image>().fillAmount = energy;
                    if (energy >=1)
                    {
                        done = true;
                        //transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
                    }
                }
                else
                {
                    gaugeImage.SetActive(false);
                }
                if(index == 2)
                {
                    if (houseManager.targetObj == gameObject)
                    {
                        houseManager.targetObj = null;
                    }
                }
                if (index == 3)
                {
                    catched = true;
                }

                if (canMove)
                {
                    float distTarget = Vector3.Distance(transform.position, targetPos[index].position);
                    if (distTarget > 0.2f)
                    {
                        lineIndex = index;
                        transform.position = Vector3.MoveTowards(transform.position, targetPos[index].position, moveSpeed);
                        moveDelayCount = 0;
                        catchCount = 0;
                    }
                    else
                    {

                    }
                }
                else
                {
                    //if (seatManager.catchObj)
                    //{
                    //    catchCount++;
                    //    if (catchCount == 1)
                    //    {
                    //        index++;
                    //    }
                    //}
                }
            }
            else
            {
                index = 3;
                if (houseManager.targetObj == gameObject)
                {
                    houseManager.targetObj = null;
                }
                switch (type)
                {
                    case 0:
                        float distTrash = Vector3.Distance(transform.position, endPos.position);
                        if (distTrash > 0.5f)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, endPos.position, moveSpeed * 3);
                        }
                        else
                        {
                            Destroy(gameObject);
                        }
                        break;
                    case 1:

                        float distWater = Vector3.Distance(transform.position, endPos.position);
                        if (distWater > 0.5f)
                        {

                            transform.position = Vector3.MoveTowards(transform.position, endPos.position, moveSpeed * 3);
                        }
                        else
                        {
                            Destroy(gameObject);
                        }
                        break;
                   
                }
            }
        }
        else
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "before")
        {

        }
        if (collision.gameObject.tag == "select")
        {

        }
        if (collision.gameObject.tag == "after")
        {

        }
        if (collision.gameObject.tag == "end")
        {
            catched = true;
        }
    }

}
