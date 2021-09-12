using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundAndEffect : MonoBehaviour
{
    [SerializeField] AudioClip mouseEnterSound;
    [SerializeField] AudioClip mouseClickSound;
    [SerializeField] AudioClip mouseEnterBooksSound;
    [SerializeField] AudioClip mouseClickBooksSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseEnterBookButton(Button button)
    {
        if(button.interactable)
        {
            SoundManager.instance.soundEffect.PlayOneShot(mouseEnterBooksSound);
        }
    }

    public void OnMouseClickBookButton()
    {
        SoundManager.instance.soundEffect.PlayOneShot(mouseClickBooksSound);
    }

    public void OnMouseEnterFunc(Button buttons)
    {
        if (buttons.interactable)
        {
            SoundManager.instance.soundEffect.PlayOneShot(mouseEnterSound);

            if (buttons.GetComponentInChildren<TextMeshProUGUI>() != null)
            {
                buttons.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
            }
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

    public void OnMouseExitUseFunc(Button buttons)
    {
        if (buttons.GetComponentInChildren<TextMeshProUGUI>() != null)
        {
            //buttons.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
            buttons.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        }
    }

    public void OnMouseClickFunc()
    {
        SoundManager.instance.soundEffect.PlayOneShot(mouseClickSound);
    }

    public void OnMouseEnterInventory(Button buttons)
    {

        if (buttons.interactable)
        {
            if (GameManager.instance.inventoryContainer.slots[buttons.GetComponent<InventoryButtons>().myIndex].item != null)
            {
                SoundManager.instance.soundEffect.PlayOneShot(mouseEnterSound);
            }
        }
    }

    public void OnMouseClickInventory(Button buttons)
    {

        if (buttons.interactable)
        {
            if (GameManager.instance.inventoryContainer.slots[buttons.GetComponent<InventoryButtons>().myIndex].item != null)
            {
                SoundManager.instance.soundEffect.PlayOneShot(mouseClickSound);
            }
        }

    }

    public void OnMouseEnterButtonWithoutChgTextColor(Button buttons)
    {

        if (buttons.interactable)
        {
            {
                SoundManager.instance.soundEffect.PlayOneShot(mouseEnterSound);
            }
        }
    }

}
