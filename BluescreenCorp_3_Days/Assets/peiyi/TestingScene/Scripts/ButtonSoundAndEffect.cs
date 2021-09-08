using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonSoundAndEffect : MonoBehaviour
{
    [SerializeField] AudioClip mouseEnterSound;
    [SerializeField] AudioClip mouseClickSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseEnterFunc(Button buttons)
    {
        if (buttons.interactable)
        {
            SoundManager.instance.soundEffect.PlayOneShot(mouseEnterSound);
        }

        if (buttons.GetComponentInChildren<TextMeshProUGUI>() != null)
        {
            buttons.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
        }
    }

    public void OnMouseExitFunc(Button buttons)
    {
        if (buttons.GetComponentInChildren<TextMeshProUGUI>() != null)
        {
            //buttons.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
            buttons.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }
    }

    public void OnMouseClickFunc()
    {
        SoundManager.instance.soundEffect.PlayOneShot(mouseClickSound);
    }
}
