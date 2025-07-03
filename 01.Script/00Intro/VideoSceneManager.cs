using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSceneManager : MonoBehaviour
{
    public VideoClip vid;

    private void Start()
    {
        StartCoroutine(VidPlay());
    }
    private void Update()
    {
        if (Input.GetButtonDown("1P_B") || Input.GetButtonDown("2P_B") || Input.GetButtonDown("3P_B") || Input.GetAxisRaw("4P_B") ==1 || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(2);
        }
    }

    IEnumerator VidPlay()
    {
        yield return new WaitForSeconds((float)vid.length);
        SceneManager.LoadScene(2);
    }
}
