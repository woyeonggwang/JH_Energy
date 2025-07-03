using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    public Transform mat;
    public bool talk;

    private void Start()
    {
        talk = false;
    }

    public void Update()
    {
        if (talk)
        {
            mat.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_isTalking", 1);
        }
        else
        {
            mat.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_isTalking", 0);
        }
    }

    public void TalkBegin()
    {

        talk = true;

    }
    public void TalkOut()
    {
        print(0);
        talk = false;

    }

}
