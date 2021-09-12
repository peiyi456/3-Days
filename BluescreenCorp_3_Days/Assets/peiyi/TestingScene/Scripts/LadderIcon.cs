using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderIcon : MonoBehaviour
{
    [SerializeField] GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = parent.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
