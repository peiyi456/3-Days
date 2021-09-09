using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingPageScripts : MonoBehaviour
{
    public static int loadSceneNumber;
    [SerializeField] GameObject KeyInstructionPage;

    // Start is called before the first frame update
    void Start()
    {
        if(loadSceneNumber == 3 || loadSceneNumber ==4)
        {
            KeyInstructionPage.SetActive(true);
        }
        else
        {
            KeyInstructionPage.SetActive(false);
        }

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
