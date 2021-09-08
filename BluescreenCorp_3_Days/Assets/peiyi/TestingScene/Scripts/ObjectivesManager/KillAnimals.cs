using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillAnimals : MonoBehaviour
{
    public static KillAnimals instance;

    private void Awake()
    {
        instance = this;
    }


    [SerializeField] string Description;
    [SerializeField] TextMeshProUGUI objectiveText;

    public int killAnimalNumber;
    [SerializeField] int targetTotalNumber;
    [SerializeField] string target1;
    [SerializeField] string target2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.thisAnimal.Name == target1 || GameManager.instance.thisAnimal.Name == target2)
        {
            if (GameManager.instance.enemyFainted == true)
            {
                killAnimalNumber += 1;
            }
        }

        if(killAnimalNumber >= targetTotalNumber)
        {
            objectiveText.fontStyle = FontStyles.Strikethrough | FontStyles.Bold | FontStyles.Italic;
            objectiveText.color = Color.blue;
            GameManager.instance.Objective3 = true;
        }

        else
        {
            objectiveText.fontStyle = FontStyles.Bold | FontStyles.Italic;
            objectiveText.color = Color.black;
            GameManager.instance.Objective3 = false;
        }
    }
}
