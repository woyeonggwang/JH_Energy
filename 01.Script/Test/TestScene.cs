using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TestTest());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TestTest()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
    }
}
