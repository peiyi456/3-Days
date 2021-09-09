using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PutAllCampsite : MonoBehaviour
{
    [SerializeField] string Description;
    [SerializeField] TextMeshProUGUI objectiveText;

    // Start is called before the first frame update
    void Start()
    {
        objectiveText.text = Description;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.CampSetupNumber >= 2)
        {
            objectiveText.fontStyle = FontStyles.Strikethrough | FontStyles.Bold | FontStyles.Italic;
            objectiveText.color = Color.blue;
            GameManager.instance.Objective1 = true;
        }

        else
        {
            objectiveText.fontStyle = FontStyles.Bold | FontStyles.Italic;
            objectiveText.color = Color.black;
            GameManager.instance.Objective1 = false;
        }
    }
}
