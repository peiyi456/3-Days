using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingPageScripts : MonoBehaviour
{
    public static int loadSceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Run: " + Time.timeScale);
        Debug.Log(loadSceneNumber);
        StartCoroutine(ChangeScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(loadSceneNumber);
    }
}
