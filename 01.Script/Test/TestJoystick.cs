using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJoystick : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetButtonDown("A"))
        {
            //SceneManager.LoadScene(0);
            //udp.GetComponent<UDPDebug>().SendMsg(sceneString[0]);
            print(0);
        }
        if (Input.GetButtonUp("A"))
        {
            print(1);
        }
        if (Input.GetButtonDown("B"))
        {
            print(2);
        }
    }
}
