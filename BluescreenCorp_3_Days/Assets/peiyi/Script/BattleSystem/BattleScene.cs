using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleScene : MonoBehaviour
{
    [SerializeField] GameObject mainScene;
    [SerializeField] GameObject combatScene;
    [SerializeField] Camera combatCamera;
    [SerializeField] Camera maincamera;
    //AnimalSpawnerScript animalSpawn;

    // Start is called before the first frame update
    void Start()
    {
        mainScene.SetActive(true);
        combatScene.SetActive(false);
        //maincamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Animal"))
        {
            mainScene.SetActive(false);
            combatScene.SetActive(true);
            
            //combatCamera = Camera.main;
            AnimalSpawnerScript.animalNo--;

            Destroy(collision.gameObject);
        }
    }
}
