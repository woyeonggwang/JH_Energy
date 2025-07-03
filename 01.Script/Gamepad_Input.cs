using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamepad_Input : MonoBehaviour
{
    public Text text;
    private string tmp;
    private float joystickVal;
    private float posXVal;
    private List<string> buttons = new List<string>() { "1P_A", "1P_B", "1P_X", "space", "2P_A", "2P_B", "2P_X", "space", "3P_A", "3P_B", "3P_X", "space", "4P_A", "4P_B", "4P_X" };
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        string tmp = string.Empty;
        foreach (var button in buttons)
        {
            if (button == "space")
            {
                tmp = tmp + "      ";
            }
            else if (Input.GetButton(button))
            {
                tmp = tmp + "● ";
            }
            else
            {
                tmp = tmp + "○ ";
            }
        }
        joystickVal = Input.GetAxisRaw("1P_axis");
        posXVal=remap(joystickVal, -1, 1, -66, 66);
        print(joystickVal + "--joystick--"+posXVal+"pos");
        print(Input.GetAxisRaw("3P_axis") + "-----------------" + Input.GetAxisRaw("4P_axis"));
        text.text = tmp;
        //print(tmp);
        //print(Input.GetAxisRaw("1P_axis") + "   " + Input.GetButtonDown("1P_A") + "   " + Input.GetButtonDown("1P_B") + "  " + Input.GetButtonDown("1P_X"));
        print(Input.GetButtonDown("1P_A") + "   " + Input.GetButtonDown("1P_B") + "  " + Input.GetButtonDown("1P_X") + "             " + Input.GetButtonDown("2P_A") + "   " + Input.GetButtonDown("2P_B") + "  " + Input.GetButtonDown("2P_X") + "             " + Input.GetButtonDown("3P_A") + "   " + Input.GetButtonDown("3P_B") + "  " + Input.GetButtonDown("3P_X") + "             " + Input.GetButtonDown("4P_A") + "   " + Input.GetButtonDown("4P_B") + "  " + Input.GetButtonDown("4P_X"));

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("a");

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            print("b");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            print("c");
        }
        //if(Input.GetKeyDown() 슬라이드
    }
    public static float remap(float val, float in1, float in2, float out1, float out2)  //리맵하는 함수
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }
}
