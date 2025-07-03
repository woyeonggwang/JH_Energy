using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Stage01SeatController : MonoBehaviour
{

    public Stage0102Main stageMain;

    public GameObject target;
    public int seatNum;
    public bool onPlay;
    public GameObject water;
    public Transform[] spawn00;
    public Transform[] spawn01;
    public Transform[] spawn02;
    public int objExistCount;
    public Transform[] spawn03;
    public Canvas canvas;
    public Transform[] spawnPos;
    public Transform seat0Pos;
    public Transform seat1Pos;
    public Transform seat2Pos;
    public Transform seat3Pos;
    public GameObject selectbarParent;
    public AudioSource countSound;

    public bool gameStart;

    public int score; //점수
    public GameObject[] targetComponent = new GameObject[5];
    private int targetIndex;
    //public bool[] enableSeat00=new bool[5];
    //public bool[] enableSeat01=new bool[5];
    //public bool[] enableSeat02=new bool[5];
    //public bool[] enableSeat03=new bool[5];
    //public bool[] enableSeat04=new bool[5];

    public bool[] enableSeat = new bool[5];

    private Transform seatPos;
    private int player4BCount;
    private int player4XCount;
    private float waterGravity;
    private bool seat0Bool;
    private bool seat1Bool;
    private bool seat2Bool;
    private bool seat3Bool;
    private int[] ran = new int[5];
    private int ranIndex;
    [Header("select bar")]
    public Transform selectBar;
    private float[] selectBarX = { -373, -183, 0, 183, 371 };
    [HideInInspector] public int selectIndex;
    private float joystickVal;
    private float posXVal;
    private float delayTime;
    [HideInInspector] public int spawnCount;
    public float posValRight;
    public float posValLeft;
    public float range;

    private void Start()
    {
        targetIndex = 0;
        ran = Enumerable.Range(0, 5).ToArray();
        for (int i = 0; i < 5; i++)
        {
            int ranIdx = Random.Range(i, 5);
            int tmp = ran[ranIdx];
            ran[ranIdx] = ran[i];
            ran[i] = tmp;
        }
        waterGravity = 5f;
        spawnCount = 0;
        delayTime = 2f;
        onPlay = false;
        spawnPos = new Transform[5];
        selectIndex = 2;
        for (int i = 0; i < 5; i++)
        {
            enableSeat[i] = true;
        }
        switch (seatNum)
        {
            case 0:
                for (int i = 0; i < spawn00.Length; i++)
                {
                    spawnPos[i] = spawn00[i];
                }
                seatPos = seat0Pos;
                seat0Bool = true;
                seat1Bool = false;
                seat2Bool = false;
                seat3Bool = false;
                break;
            case 1:
                for (int i = 0; i < spawn01.Length; i++)
                {
                    spawnPos[i] = spawn01[i];
                }
                seatPos = seat1Pos;
                seat0Bool = false;
                seat1Bool = true;
                seat2Bool = false;
                seat3Bool = false;
                break;
            case 2:
                for (int i = 0; i < spawn02.Length; i++)
                {
                    spawnPos[i] = spawn02[i];
                }
                seatPos = seat2Pos;
                seat0Bool = false;
                seat1Bool = false;
                seat2Bool = true;
                seat3Bool = false;
                break;
            case 3:
                for (int i = 0; i < spawn03.Length; i++)
                {
                    spawnPos[i] = spawn03[i];
                }
                seatPos = seat3Pos;
                seat0Bool = false;
                seat1Bool = false;
                seat2Bool = false;
                seat3Bool = true;
                break;
        }
    }
    private void Update()
    {

        

        //print(enableSeat00[0]+ "---"+ enableSeat00[1] + "---" + enableSeat00[2] + "---" + enableSeat00[3]);
        if (onPlay)
        {
            try
            {
                for (int i = 0; i < targetComponent.Length; i++)
                {
                    if (!targetComponent[i].activeInHierarchy)
                    {
                        Destroy(targetComponent[i]);
                        targetComponent[i] = null;
                    }
                }

            }
            catch
            {

            }
            selectbarParent.SetActive(true);
            switch (seatNum)
            {
                case 0:
                    joystickVal = Input.GetAxisRaw("1P_axis");
                    posXVal = remap(joystickVal, -1, 1, -66, 66);
                    if (Input.GetButtonDown("1P_A") || Input.GetButtonDown("1P_B") || Input.GetButtonDown("1P_X"))
                    {
                        if (targetComponent[selectIndex] != null && targetComponent[selectIndex].GetComponent<WaterController>().canSee)
                        {
                            countSound.Play();
                            targetComponent[selectIndex].GetComponent<WaterController>().count--;
                        }
                    }
                    break;
                case 1:
                    joystickVal = Input.GetAxisRaw("2P_axis");
                    posXVal = remap(joystickVal, -1, 1, -66, 66);
                    if (Input.GetButtonDown("2P_A") || Input.GetButtonDown("2P_B") || Input.GetButtonDown("2P_X"))
                    {
                        if (targetComponent[selectIndex] != null && targetComponent[selectIndex].GetComponent<WaterController>().canSee)
                        {
                            countSound.Play();
                            targetComponent[selectIndex].GetComponent<WaterController>().count--;
                        }
                    }
                    break;
                case 2:
                    joystickVal = Input.GetAxisRaw("3P_axis");
                    posXVal = remap(joystickVal, 0, 1, -66, 66);
                    if (Input.GetButtonDown("3P_A") || Input.GetButtonDown("3P_B") || Input.GetButtonDown("3P_X"))
                    {
                        if (targetComponent[selectIndex] != null && targetComponent[selectIndex].GetComponent<WaterController>().canSee)
                        {
                            countSound.Play();
                            targetComponent[selectIndex].GetComponent<WaterController>().count--;
                        }
                    }
                    break;
                case 3:
                    joystickVal = Input.GetAxisRaw("4P_axis");
                    posXVal = remap(joystickVal, 0, 1, -66, 66);
                    if (Input.GetButtonDown("4P_B"))
                    {
                        if (targetComponent[selectIndex] != null && targetComponent[selectIndex].GetComponent<WaterController>().canSee)
                        {
                            countSound.Play();
                            targetComponent[selectIndex].GetComponent<WaterController>().count--;
                        }
                    }
                    if (Input.GetAxisRaw("4P_A") == 1)
                    {
                        player4BCount++;
                        if (player4BCount == 1)
                        {

                            if (targetComponent[selectIndex] != null && targetComponent[selectIndex].GetComponent<WaterController>().canSee)
                            {
                                countSound.Play();
                                targetComponent[selectIndex].GetComponent<WaterController>().count--;
                            }
                        }
                    }
                    else if (Input.GetAxisRaw("4P_A") == 0)
                    {
                        player4BCount = 0;
                    }
                    if (Input.GetAxisRaw("4P_X") == 1)
                    {
                        player4XCount++;
                        if (player4XCount == 1)
                        {
                            if (targetComponent[selectIndex] != null && targetComponent[selectIndex].GetComponent<WaterController>().canSee)
                            {
                                countSound.Play();
                                targetComponent[selectIndex].GetComponent<WaterController>().count--;
                            }
                        }
                    }
                    else if (Input.GetAxisRaw("4P_X") == 0)
                    {
                        player4XCount = 0;
                    }

                    break;
            }
            if (delayTime > 0.35f)
            {
                delayTime -= 0.5f* Time.deltaTime;
            }
            selectBar.localPosition = new Vector3(selectBarX[selectIndex], selectBar.localPosition.y, selectBar.localPosition.z);
            if (posXVal < -50)
            {
                selectIndex = 0;
            }
            if (posXVal > -51 && posXVal < -19)
            {
                selectIndex = 1;

            }
            if (posXVal > -20 && posXVal < 20)
            {
                selectIndex = 2;

            }
            if (posXVal < 51 && posXVal > 19)
            {
                selectIndex = 3;

            }
            if (posXVal > 50)
            {
                selectIndex = 4;

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {

            }
            if (objExistCount < 4)
            {

                spawnCount++;
                if (spawnCount == 1)
                {
                    print(0);

                    StartCoroutine(SpawnPlay());


                }
            }
            else
            {
                spawnCount = 0;
            }
        }
        else
        {
            selectbarParent.SetActive(false);
        }

    }


    IEnumerator SpawnPlay()
    {


        GameObject obj = Instantiate(water, spawnPos[ran[ranIndex]].position, Quaternion.identity, canvas.transform);
        obj.SetActive(true);
        obj.transform.parent = seatPos;
        if (waterGravity < 25)
        {
            waterGravity += 0.4f;
        }
        obj.GetComponent<WaterController>().count = Random.Range(1, 6);
        obj.GetComponent<WaterController>().seatIndex = seatNum;
        obj.GetComponent<WaterController>().lineIndex = ran[ranIndex];
        obj.GetComponent<WaterController>().ran = ran[ranIndex];

        obj.GetComponent<Rigidbody2D>().gravityScale = waterGravity;
        targetComponent[ran[ranIndex]] = obj;
        //enableSeat[ran[ranIndex]] = false;

        if (ranIndex >= 4)
        {
            //ran = Enumerable.Range(0, 5).ToArray();
            //for (int i = 0; i < 5; i++)
            //{
            //    int ranIdx = Random.Range(i, 5);
            //    int tmp = ran[ranIdx];
            //    ran[ranIdx] = ran[i];
            //    ran[i] = tmp;
            //}
            ranIndex = 0;
            targetIndex = 0;
        }
        else
        {
            ranIndex++;
            targetIndex++;
        }
        yield return new WaitForSeconds(delayTime);
        spawnCount = 0;

    }
    public static float remap(float val, float in1, float in2, float out1, float out2)  //리맵하는 함수
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }
}
