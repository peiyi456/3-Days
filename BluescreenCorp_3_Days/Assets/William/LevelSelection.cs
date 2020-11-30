using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public GameObject levelSelection;
    

    int currentSortingNumber;

    void Start()
    {
        levelSelection.GetComponent<Renderer>().sortingOrder = currentSortingNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
