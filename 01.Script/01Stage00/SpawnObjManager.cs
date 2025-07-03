using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjManager : MonoBehaviour
{

    public SeatManager seatManager;
    public int seatNum;
    public int type;
    public Transform[] targetPos;
    public Transform trashEndPoint;
    public Transform waterEndPoint;
    public Transform fishEndPoint;
    public Transform outline;
    public int index;
    public int lineIndex;
    public int seatGetIndex;
    public bool canMove;
    public bool clicked;
    public bool selected;
    public bool catched;
    public bool lost;
    
    private int catchCount;
    private int moveDelayCount;
    private int leftIndex;
    private void Start()
    {
        outline.GetComponent<Outline>().enabled = false;
        canMove = true;
        selected = false;
        lost = false;
    }

    private void Update()
    {

        //catch가 false일때 canmove 면 이동 아니면 딜레이줘서 다시 canmove활성화
        if (!lost)
        {

            if (!catched)
            {
                if (index < 6)
                {
                    seatManager.lineObj[index] = gameObject;
                }
                if (index == 6 && seatManager.targetObj == null)
                {
                    seatManager.targetObj = gameObject;
                    outline.GetComponent<Outline>().enabled = true;
                }

                if (canMove)
                {
                    float distTarget = Vector3.Distance(transform.position, targetPos[index].position);
                    if (distTarget > 0.2f)
                    {
                        lineIndex = index;
                        transform.position = Vector3.MoveTowards(transform.position, targetPos[index].position, seatManager.moveSpeed);
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
                index = 7;
                if (seatManager.targetObj == gameObject)
                {
                    seatManager.targetObj = null;
                }
                switch (type)
                {
                    case 0:
                        float distTrash = Vector3.Distance(transform.position, trashEndPoint.position);
                        if (distTrash > 0.5f)
                        {
                            catchCount++;
                            if (catchCount == 1)
                            {
                                seatManager.targetObj = null;
                            }
                            transform.position = Vector3.MoveTowards(transform.position, trashEndPoint.position, seatManager.moveSpeed * 3);
                        }
                        else
                        {
                            Destroy(gameObject);
                        }
                        break;
                    case 1:
                        
                        float distWater = Vector3.Distance(transform.position, waterEndPoint.position);
                        if (distWater > 0.5f)
                        {

                            catchCount++;
                            if (catchCount == 1)
                            {
                                seatManager.targetObj = null;
                            }
                            transform.position = Vector3.MoveTowards(transform.position, waterEndPoint.position, seatManager.moveSpeed * 3);
                        }
                        else
                        {
                            Destroy(gameObject);
                        }
                        break;
                    case 2:
                        float distFish = Vector3.Distance(transform.position, fishEndPoint.position);
                        if (distFish > 0.5f)
                        {
                            catchCount++;
                            if (catchCount == 1)
                            {
                                seatManager.targetObj = null;
                            }
                            transform.position = Vector3.MoveTowards(transform.position, fishEndPoint.position, seatManager.moveSpeed * 3);
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

    IEnumerator MoveDelay()
    {
        yield return new WaitForSeconds(1f);
        canMove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "linepoint")
        {
            print("line point");
            //canMove = false;
        }
        //if (other.gameObject.tag == "endpoint")
        //{
        //    if (!catched)
        //    {

        //        lost = true;
        //        print("lost");
        //    }
        //}
        if (other.gameObject.tag == "selected")
        {
            seatManager.targetObj = gameObject;
            selected = true;
            //canMove = false;
            print("selectPoint");
        }
        

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "selected")
        {
            seatManager.targetObj = null;
            selected = false;

            print("selectPoint");
        }
       
    }


}
