using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatManager : MonoBehaviour
{
    public bool catchObj;
    public Transform spawnPoint;
    public int seatNum;
    public Transform[] target;
    public GameObject[] trash;
    public GameObject[] lineObj = new GameObject[7];
    public GameObject water;
    public GameObject fish;
    public Animator sign;
    public bool onPlay;
    public float moveSpeed;
    private int player4ACount;
    private int player4XCount;

    public GameObject targetObj;
    public GameObject firstObj;
    public GameObject secondObj;
    public GameObject thirdObj;
    public GameObject fourthObj;
    public GameObject fifthObj;
    public GameObject sixthObj;
    public AudioSource correctSound;
    public AudioSource disCorrectSound;
    public List<GameObject> spawnObj = new List<GameObject>();
    private int score;
    private int catchCount;
    private int objIndex;
    private int type;
    public bool canClick;
    private bool closeFront;
    private int spawnCount;
    public int spawnIndexCheck;

    private void Start()
    {
        score = 0;
        onPlay = false;
        StartCoroutine(SpawnPlay());
        spawnIndexCheck = 0;
        player4ACount = 0;
        player4XCount = 0;

        canClick = true;
    }


    private void Update()
    {
        if (onPlay)
        {
            if (firstObj == null)
            {

                spawnCount++;
                if (spawnCount == 1)
                {

                }
            }
            if (targetObj != null)
            {
                if (canClick)
                {

                    switch (seatNum)
                    {
                        case 0:
                            switch (targetObj.GetComponent<SpawnObjManager>().type)
                            {
                                case 0:

                                    if (Input.GetButtonDown("1P_A") || Input.GetKeyDown(KeyCode.A))
                                    {
                                        
                                        if (!targetObj.GetComponent<SpawnObjManager>().catched)
                                        {
                                            targetObj.GetComponent<SpawnObjManager>().catched = true;
                                            StartCoroutine(CatchPlay());

                                        }
                                    }
                                    if (Input.GetButtonDown("1P_B") || Input.GetButtonDown("1P_X"))
                                    {
                                        disCorrectSound.Play();
                                        StartCoroutine(ClickDelay());
                                    }
                                    break;
                                case 1:
                                    if (Input.GetButtonDown("1P_X") || Input.GetKeyDown(KeyCode.D))
                                    {
                                        
                                        if (!targetObj.GetComponent<SpawnObjManager>().catched)
                                        {
                                            targetObj.GetComponent<SpawnObjManager>().catched = true;
                                            StartCoroutine(CatchPlay());
                                        }
                                    }
                                    if (Input.GetButtonDown("1P_A") || Input.GetButtonDown("1P_B"))
                                    {
                                        disCorrectSound.Play();
                                        StartCoroutine(ClickDelay());
                                    }
                                    break;
                                case 2:
                                    if (Input.GetButtonDown("1P_B") || Input.GetKeyDown(KeyCode.S))
                                    {
                                        
                                        if (!targetObj.GetComponent<SpawnObjManager>().catched)
                                        {
                                            targetObj.GetComponent<SpawnObjManager>().catched = true;
                                            StartCoroutine(CatchPlay());
                                            StartCoroutine(SignPlay());
                                        }


                                    }
                                    if (Input.GetButtonDown("1P_A") || Input.GetButtonDown("1P_X"))
                                    {
                                        disCorrectSound.Play();
                                        StartCoroutine(ClickDelay());
                                    }

                                    break;

                            }
                            break;
                        case 1:
                            switch (targetObj.GetComponent<SpawnObjManager>().type)
                            {
                                case 0:

                                    if (Input.GetButtonDown("2P_A"))
                                    {
                                       
                                        if (!targetObj.GetComponent<SpawnObjManager>().catched)
                                        {
                                            targetObj.GetComponent<SpawnObjManager>().catched = true;
                                            StartCoroutine(CatchPlay());
                                        }

                                    }
                                    if (Input.GetButtonDown("2P_B") || Input.GetButtonDown("2P_X"))
                                    {
                                        disCorrectSound.Play();
                                        StartCoroutine(ClickDelay());
                                    }
                                    break;
                                case 1:
                                    if (Input.GetButtonDown("2P_X"))
                                    {
                                       

                                        if (!targetObj.GetComponent<SpawnObjManager>().catched)
                                        {
                                            targetObj.GetComponent<SpawnObjManager>().catched = true;
                                            StartCoroutine(CatchPlay());
                                        }
                                    }
                                    if (Input.GetButtonDown("2P_A") || Input.GetButtonDown("2P_B"))
                                    {
                                        disCorrectSound.Play();
                                        StartCoroutine(ClickDelay());
                                    }
                                    break;
                                case 2:
                                    if (Input.GetButtonDown("2P_B"))
                                    {
                                     
                                        if (!targetObj.GetComponent<SpawnObjManager>().catched)
                                        {
                                            targetObj.GetComponent<SpawnObjManager>().catched = true;
                                            StartCoroutine(CatchPlay());
                                            StartCoroutine(SignPlay());
                                        }
                                    }
                                    if (Input.GetButtonDown("2P_A") || Input.GetButtonDown("2P_X"))
                                    {
                                        disCorrectSound.Play();
                                        StartCoroutine(ClickDelay());
                                    }

                                    break;

                            }
                            break;
                        case 2:
                            switch (targetObj.GetComponent<SpawnObjManager>().type)
                            {
                                case 0:

                                    if (Input.GetButtonDown("3P_A"))
                                    {
                                        
                                        if (!targetObj.GetComponent<SpawnObjManager>().catched)
                                        {
                                            targetObj.GetComponent<SpawnObjManager>().catched = true;
                                            StartCoroutine(CatchPlay());
                                        }
                                    }
                                    if (Input.GetButtonDown("3P_B") || Input.GetButtonDown("3P_X"))
                                    {
                                        disCorrectSound.Play();
                                        StartCoroutine(ClickDelay());
                                    }
                                    break;
                                case 1:
                                    if (Input.GetButtonDown("3P_X"))
                                    {
                                        

                                        if (!targetObj.GetComponent<SpawnObjManager>().catched)
                                        {
                                            targetObj.GetComponent<SpawnObjManager>().catched = true;
                                            StartCoroutine(CatchPlay());
                                        }
                                    }
                                    if (Input.GetButtonDown("3P_A") || Input.GetButtonDown("3P_B"))
                                    {
                                        disCorrectSound.Play();
                                        StartCoroutine(ClickDelay());
                                    }
                                    break;
                                case 2:
                                    if (Input.GetButtonDown("3P_B"))
                                    {
                                        
                                        if (!targetObj.GetComponent<SpawnObjManager>().catched)
                                        {
                                            targetObj.GetComponent<SpawnObjManager>().catched = true;
                                            StartCoroutine(CatchPlay());
                                            StartCoroutine(SignPlay());
                                        }
                                    }
                                    if (Input.GetButtonDown("3P_A") || Input.GetButtonDown("3P_X"))
                                    {
                                        disCorrectSound.Play();
                                        StartCoroutine(ClickDelay());
                                    }

                                    break;

                            }
                            break;
                        case 3:
                            switch (targetObj.GetComponent<SpawnObjManager>().type)
                            {
                                case 0:

                                    if (Input.GetAxisRaw("4P_A") == 1)
                                    {
                                        player4ACount++;
                                        if (player4ACount == 1)
                                        {
                                            
                                            if (!targetObj.GetComponent<SpawnObjManager>().catched)
                                            {
                                                targetObj.GetComponent<SpawnObjManager>().catched = true;
                                                StartCoroutine(CatchPlay());
                                            }
                                        }
                                    }
                                    else
                                    {
                                        player4ACount = 0;
                                    }
                                    if (Input.GetAxisRaw("4P_B") == 1)
                                    {
                                        player4ACount++;
                                        if (player4ACount == 1)
                                        {
                                            StartCoroutine(ClickDelay());
                                            disCorrectSound.Play();
                                        }
                                    }
                                    else if (Input.GetAxisRaw("4P_B") == 0)
                                    {
                                        player4ACount = 0;
                                    }
                                    if (Input.GetAxisRaw("4P_X") == 1)
                                    {
                                        player4XCount++;
                                        if (player4XCount == 1)
                                        {
                                            StartCoroutine(ClickDelay());
                                            disCorrectSound.Play();
                                        }
                                    }
                                    else if (Input.GetAxisRaw("4P_X") == 0)
                                    {
                                        player4XCount = 0;
                                    }

                                    break;
                                case 1:
                                    if (Input.GetAxisRaw("4P_X") == 1)
                                    {

                                        player4XCount++;
                                        if (player4XCount == 1)
                                        {
                                            
                                            if (!targetObj.GetComponent<SpawnObjManager>().catched)
                                            {

                                                targetObj.GetComponent<SpawnObjManager>().catched = true;
                                                StartCoroutine(CatchPlay());
                                            }
                                        }
                                    }
                                    else if (Input.GetAxisRaw("4P_X") == 0)
                                    {
                                        player4XCount = 0;
                                    }
                                    if (Input.GetButtonDown("4P_B"))
                                    {
                                        disCorrectSound.Play();
                                        StartCoroutine(ClickDelay());

                                    }
                                    if (Input.GetAxisRaw("4P_A") == 1)
                                    {
                                        player4ACount++;
                                        if (player4ACount == 1)
                                        {
                                            disCorrectSound.Play();
                                            StartCoroutine(ClickDelay());
                                        }
                                    }
                                    else if (Input.GetAxisRaw("4P_A") == 0)
                                    {
                                        player4ACount = 0;
                                    }
                                    break;
                                case 2:
                                    if (Input.GetButtonDown("4P_B"))
                                    {
                                        

                                        if (!targetObj.GetComponent<SpawnObjManager>().catched)
                                        {
                                            targetObj.GetComponent<SpawnObjManager>().catched = true;
                                            StartCoroutine(CatchPlay());
                                            StartCoroutine(SignPlay());
                                        }

                                    }
                                    //else if (Input.GetAxisRaw("4P_B") == 0)
                                    //{
                                    //    player4BCount = 0;
                                    //}

                                    if (Input.GetAxisRaw("4P_X") == 1)
                                    {
                                        player4XCount++;
                                        if (player4XCount == 1)
                                        {
                                            StartCoroutine(ClickDelay());
                                            disCorrectSound.Play();
                                        }
                                    }
                                    else if (Input.GetAxisRaw("4P_X") == 0)
                                    {
                                        player4XCount = 0;
                                    }
                                    if (Input.GetButtonDown("4P_A"))
                                    {
                                        player4ACount++;
                                        if (player4ACount == 1)
                                        {
                                            StartCoroutine(ClickDelay());
                                            disCorrectSound.Play();
                                        }
                                    }
                                    else if (Input.GetAxisRaw("4P_A") == 0)
                                    {
                                        player4ACount = 0;
                                    }
                                    break;


                            }
                            break;
                    }

                }
            }

        }
        else
        {


        }

    }

    IEnumerator ClickDelay()
    {
        canClick = false;
        yield return new WaitForSeconds(0.5f);
        canClick = true;
    }

    IEnumerator SpawnPlay()
    {
        type = Random.Range(0, 3);
        yield return new WaitForSeconds(0.1f);
        switch (type)
        {
            case 0:
                Spawn(trash[Random.Range(0, trash.Length)], type);
                break;
            case 1:
                Spawn(water, type);
                break;
            case 2:
                Spawn(fish, type);
                break;
        }
        yield return new WaitForSeconds(0.1f);
        spawnIndexCheck++;
        if (spawnIndexCheck < 7)
        {
            StartCoroutine(SpawnPlay());
        }
    }

    private void Spawn(GameObject obj, int type)
    {
        GameObject temp = Instantiate(obj, Vector3.zero, Quaternion.Euler(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z));
        temp.transform.parent = spawnPoint;
        temp.transform.localPosition = Vector3.zero;
        temp.SetActive(true);
        if (spawnIndexCheck < 7)
        {
            temp.GetComponent<SpawnObjManager>().index = spawnIndexCheck;
        }

        temp.GetComponent<SpawnObjManager>().seatGetIndex = spawnIndexCheck;
        temp.GetComponent<SpawnObjManager>().seatNum = seatNum;
        spawnObj.Add(temp);
    }

    IEnumerator SignPlay()
    {
        sign.SetBool("state", true);
        yield return new WaitForSeconds(0.1f);
        sign.SetBool("state", false);
    }

    IEnumerator CatchPlay()
    {
        correctSound.Play();
        catchObj = true;
        yield return new WaitForSeconds(0.115f);
        switch (seatNum)
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
        StartCoroutine(SpawnPlay());
        try
        {
            for (int i = 0; i < lineObj.Length; i++)
            {
                lineObj[i].GetComponent<SpawnObjManager>().index++;
            }

        }
        catch
        {

        }
        catchObj = false;
    }
}
