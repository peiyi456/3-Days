using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimalPageFunction : MonoBehaviour//, IPointerClickHandler
{
    [Header("Must follow the sequence number with the boolean in Game Manager MeetAnimal Checking")]
    [SerializeField] int number;

    [Header("Get Animal Details")]
    [SerializeField] _UnitsBase animals;

    [Header("Assign animal button icon and name")]
    //[SerializeField] Button animalButton;
    [SerializeField] Image animalButtonIcon;
    [SerializeField] TextMeshProUGUI animalNameText;
    //[SerializeField] List<string> animalName;

    [Header("Animal Details")]
    [SerializeField] Image animalDetailsPic;
    [SerializeField] TextMeshProUGUI animalDetailsName;
    [SerializeField] TextMeshProUGUI animalDetailsCharacteristics;
    [SerializeField] TextMeshProUGUI animalDetailsAppearIn;


    // Start is called before the first frame update
    void Start()
    {
        if (number < GameManager.instance.Animals.Length)
        {
            animals = GameManager.instance.Animals[number];
            animalButtonIcon.sprite = animals.UnitSprite;
            animalButtonIcon.color = new Color(0f, 0f, 0f, 255f);
            animalNameText.text = animals.Name;
        }
        else
        {
            animals = null;
        }
            animalNameText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        UnlockAnimalDetails();
    }

    public void UnlockAnimalDetails()
    {
        if (number < GameManager.instance.meetAnimal.Length)
        {
            if (GameManager.instance.meetAnimal[number] == true)
            {
                animalButtonIcon.color = new Color(255f, 255f, 255f, 255f);
                animalNameText.gameObject.SetActive(true);
            }
        }
    }

    public void ShowAnimalDetails()
    {
        if (animals != null)
        {
            animalDetailsPic.gameObject.SetActive(true);
            animalDetailsName.gameObject.SetActive(true);
            animalDetailsCharacteristics.gameObject.SetActive(true);
            animalDetailsAppearIn.gameObject.SetActive(true);

            animalDetailsPic.sprite = animals.UnitSprite;
            animalDetailsName.text = animals.Name;
            animalDetailsCharacteristics.text = animals.Characteristics;
            animalDetailsAppearIn.text = animals.AppearIn;

            Debug.Log("Button clicked = ");
        }
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    if (eventData.button == PointerEventData.InputButton.Left)
    //    {

    //        animalDetailsPic.gameObject.SetActive(true);
    //        animalDetailsName.gameObject.SetActive(true);
    //        animalDetailsCharacteristics.gameObject.SetActive(true);
    //        animalDetailsAppearIn.gameObject.SetActive(true);

    //        animalDetailsPic.sprite = animals.UnitSprite;
    //        animalDetailsName.text = animals.Name;
    //        animalDetailsCharacteristics.text = animals.Characteristics;
    //        animalDetailsAppearIn.text = animals.AppearIn;

    //        Debug.Log("Button clicked = ");
    //    }
    //}
}
