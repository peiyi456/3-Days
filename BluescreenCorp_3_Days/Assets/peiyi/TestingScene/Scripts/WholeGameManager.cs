using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WholeGameManager : MonoBehaviour
{
    public static WholeGameManager instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    [Header("Map Scene")]
    Scene[] MapScenes;

    [Header("Map Level Number")]
    public int MapLevel;

    [Header("Map Badge System")]
    public bool[] isUnlockMap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
