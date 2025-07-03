using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage02SeatController : MonoBehaviour
{
    public Stage0102Main stageMain;
    public GameObject energy; //�����ؾ��� ������
    public int seatNum; //��Ʈ ��ȣ
    public bool onPlay;
    public Transform[] spawnPos; //�����Ǵ� ��ġ
    public int objExistCount; //������ �������� ����� ī��Ʈ����
    public Transform energyParent; //������ ������Ʈ�� �θ�ü
    public int score;
    public int ran;
    public Transform character; //�̵���ų ĳ���� Ʈ������
    public float posValRight;
    public float posValLeft;
    public float range;
    //public Text scoreTxt;
    [HideInInspector]public int scoreVal;
    private float energyGravity; //������ �߷�
    public float spawnDelay; //���� ������
    private float gravityVal;
    private float characterPosX;
    private int spawnPlayCount;
    private float joystickVal;

    private void Start()
    {
        characterPosX = 0;
        onPlay = false;
        switch (seatNum)
        {
            case 0:
                scoreVal = GameManager.score0;
                break;
            case 1:
                scoreVal = GameManager.score1;

                break;
            case 2:
                scoreVal = GameManager.score2;

                break;
            case 3:
                scoreVal = GameManager.score3;

                break;
        }
        gravityVal = -800f;
    }

    private void Update()
    {
       
        if (onPlay)
        {
            switch (seatNum)
            {
                case 0:
                    joystickVal = Input.GetAxisRaw("1P_axis");
                    characterPosX = remap(joystickVal, -1, 1, -66, 66);
                    //characterPosX = Mathf.Lerp((joystickVal + 1) / 2, -66, 66);
                    print(joystickVal + "--joystick--" + characterPosX + "pos");
                    break;
                case 1:
                    joystickVal = Input.GetAxisRaw("2P_axis");
                    characterPosX = remap(joystickVal, -1, 1, -66, 66);
                    //characterPosX = Mathf.Lerp((joystickVal + 1) / 2, -66, 66);
                    print(joystickVal + "--joystick--" + characterPosX + "pos");

                    break;
                case 2:
                    joystickVal = Input.GetAxisRaw("3P_axis");
                    characterPosX = remap(joystickVal, 0, 1, -66, 66);
                    print(joystickVal + "--joystick--" + characterPosX + "pos");

                    break;
                case 3:
                    joystickVal = Input.GetAxisRaw("4P_axis");
                    characterPosX = remap(joystickVal,0, 1, -66, 66);
                    print(joystickVal + "--joystick--" + characterPosX + "pos");

                    break;
            }
            //scoreTxt.text = scoreVal.ToString();
            
            character.localPosition = new Vector3(characterPosX, character.localPosition.y, character.localPosition.z);
            if (spawnDelay > 0.6f)
            {
                spawnDelay -= 0.15f*Time.deltaTime;
            }
            spawnPlayCount++;
            if (spawnPlayCount == 1)
            {
                StartCoroutine(SpawnPlay());
            }
        }
    }

    IEnumerator SpawnPlay()
    {
        ran = Random.Range(0, spawnPos.Length);
        GameObject obj = Instantiate(energy, spawnPos[ran].position, Quaternion.identity);
        obj.SetActive(true);
        if (gravityVal > -4000)
        {
            gravityVal -= 90;
        }
        obj.GetComponent<Rigidbody>().AddForce(0, gravityVal, 0);
        obj.transform.parent = energyParent;
        obj.GetComponent<EnergyController>().seatIndex = seatNum;
        yield return new WaitForSeconds(spawnDelay);
        spawnPlayCount = 0;

    }

    public static float remap(float val, float in1, float in2, float out1, float out2)  //�����ϴ� �Լ�
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }
}
