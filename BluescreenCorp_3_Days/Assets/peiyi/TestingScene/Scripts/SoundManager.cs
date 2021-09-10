using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        instance = this;
    }

    [Header("Sound Manager")]
    public AudioSource soundEffect;
    public AudioSource BGM;
    public AudioSource BGM2;

    [Header("BGM")]
    public AudioClip DayBGMMusic;
    public AudioClip NightBGMMusic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
