using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimalPageFunction : MonoBehaviour, IPointerClickHandler
{
    [Header("Get Animal Details")]
    [SerializeField] _UnitsBase animals;

    [Header("Assign animal button icon and name")]
    [SerializeField] Button animalButton;
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
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UnlockAnimalDetails()
    {
        
    }

    public void ShowAnimalDetails()
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
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
}
