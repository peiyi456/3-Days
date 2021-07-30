using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftTargetItem : MonoBehaviour
{
    [SerializeField] string Description;
    [SerializeField] bool craftAxe, craftKnife;
    [SerializeField] TextMeshProUGUI objectiveText;

    // Start is called before the first frame update
    void Start()
    {
        objectiveText.text = Description;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.hasAxe == true)
        {
            craftAxe = true;
        }
        
        if(GameManager.instance.hasKnife == true)
        {
            craftKnife = true;
        }

        if(craftAxe == true && craftKnife == true)
        {
            objectiveText.fontStyle = FontStyles.Strikethrough | FontStyles.Bold | FontStyles.Italic;
            objectiveText.color = Color.green;
            GameManager.instance.Objective2 = true;
        }

        else
        {
            objectiveText.fontStyle = FontStyles.Bold | FontStyles.Italic;
            objectiveText.color = Color.black;
            GameManager.instance.Objective2 = false;
        }

        
    }
}
