using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerObjective : MonoBehaviour
{
    [SerializeField] List<string> ObjectiveList;
    [SerializeField] List<string> TargetObjectives;
    [SerializeField] int targetObjectiveNo;
    [SerializeField] TextMeshProUGUI[] ObjectiveTexts;

    private void Start()
    {
        //TargetObjectives = new List<string>(targetObjectiveNo);
        for(int i = 0; i < targetObjectiveNo; i++)
        {
            int index = Random.Range(1, ObjectiveList.Count);
            TargetObjectives.Add(ObjectiveList[index]);
            ObjectiveList.RemoveAt(index);
            ObjectiveTexts[i].text = TargetObjectives[i];
            Debug.Log(TargetObjectives[i]);

        }
    }
}
