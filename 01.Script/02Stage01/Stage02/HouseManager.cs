using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{


    public GameObject[] red;
    public GameObject[] blue;
    public GameObject targetObj;
    public Transform spawnPoint;
    public List<GameObject> spawnObj = new List<GameObject>();
    public int spawnIndexCheck;
    public bool onPlay;
    public int seatNum;
    public ParticleSystem blueParticle;
    public ParticleSystem redParticle;
    public AudioSource catchSound;
    public GameObject[] lineObj = new GameObject[5];
    public AudioSource wormSound;
    public AudioSource coolSound;
    private int player4BCount;
    private int player4XCount;
    public bool catchObj;
    private void Start()
    {
        StartCoroutine(SpawnPlay());
        onPlay = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (targetObj.GetComponent<HouseController>().done)
            {
                StartCoroutine(CatchPlay());
            }
        }
        try
        {

            if (onPlay)
            {


                switch (seatNum)
                {
                    case 0:
                        switch (targetObj.GetComponent<HouseController>().type)
                        {
                            case 0:

                                if (Input.GetButtonDown("1P_A") || Input.GetKeyDown(KeyCode.A))
                                {
                                    if (!targetObj.GetComponent<HouseController>().catched && targetObj.GetComponent<HouseController>().done)
                                    {
                                        coolSound.Play();
                                        StartCoroutine(CatchPlay());
                                        redParticle.Play();

                                    }
                                }

                                break;
                            case 1:
                                if (Input.GetButtonDown("1P_X") || Input.GetKeyDown(KeyCode.D))
                                {
                                    if (!targetObj.GetComponent<HouseController>().catched && targetObj.GetComponent<HouseController>().done)
                                    {
                                        wormSound.Play();
                                        StartCoroutine(CatchPlay());
                                        blueParticle.Play();
                                    }
                                }

                                break;

                        }
                        break;
                    case 1:
                        switch (targetObj.GetComponent<HouseController>().type)
                        {
                            case 0:

                                if (Input.GetButtonDown("2P_A"))
                                {
                                    if (!targetObj.GetComponent<HouseController>().catched && targetObj.GetComponent<HouseController>().done)
                                    {
                                        coolSound.Play();
                                        StartCoroutine(CatchPlay());
                                        redParticle.Play();
                                    }

                                }

                                break;
                            case 1:
                                if (Input.GetButtonDown("2P_X"))
                                {


                                    if (!targetObj.GetComponent<HouseController>().catched && targetObj.GetComponent<HouseController>().done)
                                    {
                                        wormSound.Play();
                                        StartCoroutine(CatchPlay());
                                        blueParticle.Play();
                                    }
                                }

                                break;

                        }
                        break;
                    case 2:
                        switch (targetObj.GetComponent<HouseController>().type)
                        {
                            case 0:

                                if (Input.GetButtonDown("3P_A"))
                                {
                                    if (!targetObj.GetComponent<HouseController>().catched && targetObj.GetComponent<HouseController>().done)
                                    {
                                        coolSound.Play();
                                        StartCoroutine(CatchPlay());
                                        redParticle.Play();
                                    }
                                }

                                break;
                            case 1:
                                if (Input.GetButtonDown("3P_X"))
                                {

                                    if (!targetObj.GetComponent<HouseController>().catched && targetObj.GetComponent<HouseController>().done)
                                    {
                                        wormSound.Play();
                                        StartCoroutine(CatchPlay());
                                        blueParticle.Play();
                                    }
                                }

                                break;


                        }
                        break;
                    case 3:
                        switch (targetObj.GetComponent<HouseController>().type)
                        {
                            case 0:

                                if (Input.GetAxisRaw("4P_A") == 1)
                                {
                                    if (!targetObj.GetComponent<HouseController>().catched && targetObj.GetComponent<HouseController>().done)
                                    {
                                        player4BCount++;
                                        if (player4BCount == 1)
                                        {

                                            StartCoroutine(CatchPlay());
                                            coolSound.Play();
                                            redParticle.Play();
                                        }
                                    }
                                }
                                else if (Input.GetAxisRaw("4P_A") == 0)
                                {
                                    player4BCount = 0;
                                }

                                break;
                            case 1:
                                if (Input.GetAxisRaw("4P_X") == 1)
                                {
                                    if (!targetObj.GetComponent<HouseController>().catched && targetObj.GetComponent<HouseController>().done)
                                    {
                                        player4XCount++;
                                        if (player4XCount == 1)
                                        {
                                            wormSound.Play();
                                            StartCoroutine(CatchPlay());
                                            blueParticle.Play();
                                        }
                                    }
                                }
                                else if (Input.GetAxisRaw("4P_X") == 0)
                                {
                                    player4XCount = 0;
                                }

                                break;

                        }
                        break;
                }
            }
        }
        catch
        {

        }

    }

    private void Spawn(GameObject obj, int type)
    {
        GameObject temp = Instantiate(obj, Vector3.zero, Quaternion.Euler(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z));
        temp.transform.parent = spawnPoint;
        temp.transform.localPosition = Vector3.zero;
        temp.SetActive(true);
        if (spawnIndexCheck < 2)
        {
            temp.GetComponent<HouseController>().index = spawnIndexCheck;
        }
        temp.GetComponent<HouseController>().type = type;
        temp.GetComponent<HouseController>().seatGetIndex = spawnIndexCheck;
        temp.GetComponent<HouseController>().seatNum = seatNum;
        spawnObj.Add(temp);
    }

    IEnumerator SpawnPlay()
    {
        int ran = Random.Range(0, 2);
        yield return new WaitForSeconds(0.1f);
        switch (ran)
        {
            case 0:
                Spawn(red[Random.Range(0, red.Length)], ran);
                break;
            case 1:
                Spawn(blue[Random.Range(0, blue.Length)], ran);
                break;
        }
        yield return new WaitForSeconds(0.1f);
        spawnIndexCheck++;
        if (spawnIndexCheck < 2)
        {
            StartCoroutine(SpawnPlay());
        }
    }
    IEnumerator CatchPlay()
    {
        //catchSound.Play();
        catchObj = true;
        yield return new WaitForSeconds(0.1f);
        switch (seatNum)
        {
            case 0:
                GameManager.score0 += 5;
                break;
            case 1:
                GameManager.score1 += 5;

                break;
            case 2:
                GameManager.score2 += 5;

                break;
            case 3:
                GameManager.score3 += 5;

                break;
        }
        StartCoroutine(SpawnPlay());
        try
        {
            for (int i = 0; i < lineObj.Length; i++)
            {
                lineObj[i].GetComponent<HouseController>().index++;
            }
        }
        catch
        {

        }
        catchObj = false;
    }

}
