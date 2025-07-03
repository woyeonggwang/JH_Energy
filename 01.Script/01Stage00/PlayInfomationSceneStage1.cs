using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayInfomationSceneStage1 : MonoBehaviour
{


    public VideoClip vid;
    public Image fade;

    private void Start()
    {
        fade.color = new Color(0, 0, 0, 1);
        StartCoroutine(VidPlay());
    }

    IEnumerator VidPlay()
    {
        for(float i=1; i>-0.1f; i -= 0.05f)
        {
            fade.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds((float)vid.length);
        for(float i=0; i<1.1f; i += 0.05f)
        {
            fade.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(4);
    }
}
