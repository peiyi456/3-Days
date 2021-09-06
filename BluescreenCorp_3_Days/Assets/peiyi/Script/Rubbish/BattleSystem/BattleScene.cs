using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleScene : MonoBehaviour
{
    //first ver with change the camera
    [SerializeField] GameObject mainScene;
    [SerializeField] GameObject combatScene;
    [SerializeField] Camera combatCamera;
    [SerializeField] Camera maincamera;
    [SerializeField] string[] animalTag;
    [SerializeField] AnimalBase[] animal;
    //public static AnimalBase thisAnimal;

    public static Vector2 position;

    //AnimalSpawnerScript animalSpawn;

    // Start is called before the first frame update
    void Start()
    {
        mainScene.SetActive(true);
        combatScene.SetActive(false);
        maincamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < animalTag.Length; i++)
        {
            if (collision.CompareTag(animalTag[i]))
            {
                //GameManager.instance.isPause = true;
                //Time.timeScale = 0;
                //Debug.Log(collision.tag);
                mainScene.SetActive(false);
                combatScene.SetActive(true);
                //maincamera.gameObject.SetActive(false);

                combatCamera = Camera.main;
                //AnimalSpawnerScript.animalNo--;
                //GameManager.instance.enemyDropPosition = collision.transform.position;
                //thisAnimalTag = collision.tag;
                //GameManager.instance.thisAnimal = animal[i];
                Destroy(collision.gameObject); // dont destroy straight
                position = this.transform.position;
            }
        }
    }


    //public static string[] animals = new string[] { "Duck", "Chicken", "Monkey"};
    //public static Vector2 charPosition = new Vector2(-22.02478f, 0f);
    //public AnimalSpawnerScript[] reference;


    //private void Start()
    //{
    //    this.transform.position = charPosition;
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //if (reference[0].No == 0)
    //    //{
    //    //    if (collision.CompareTag(animals[reference[0].No]))
    //    //    {
    //    //        //combatCamera = Camera.main;
    //    //        AnimalSpawnerScript.animalNo[0]--;
    //    //        SceneManager.LoadScene("CombatScene");
    //    //        Destroy(collision.gameObject);
    //    //        charPosition = this.transform.position;
    //    //    }
    //    //}

    //    //else if (reference[1].No == 1)
    //    //{
    //    //    if (collision.CompareTag(animals[reference[1].No]))
    //    //    {
    //    //        //combatCamera = Camera.main;
    //    //        AnimalSpawnerScript.animalNo[1]--;
    //    //        SceneManager.LoadScene("CombatScene1");
    //    //        Destroy(collision.gameObject);

    //    //        charPosition = this.transform.position;
    //    //    }
    //    //}

    //    //else if (reference[2].No == 2)
    //    //{
    //    //    if (collision.CompareTag(animals[reference[2].No]))
    //    //    {
    //    //        //combatCamera = Camera.main;
    //    //        AnimalSpawnerScript.animalNo[2]--;
    //    //        SceneManager.LoadScene("CombatScene2");
    //    //        Destroy(collision.gameObject);

    //    //        charPosition = this.transform.position;
    //    //    }
    //    //}

    //    //for (int i = 0; i < animals.Length; i++)
    //    //{
    //    //    if (collision.CompareTag(animals[i]))
    //    //    {
    //    //        //combatCamera = Camera.main;
    //    //        //AnimalSpawnerScript.animalNo--;
    //    //        SceneManager.LoadScene("CombatScene");
    //    //        Destroy(collision.gameObject);

    //    //        charPosition = this.transform.position;
    //    //    }
    //    //}

    //    if(collision.CompareTag("Duck"))
    //    {
    //        DuckSpawnerScript.duckAnimalNo--;
    //        SceneManager.LoadScene(3);
    //        Destroy(collision.gameObject);

    //        charPosition = this.transform.position;
    //    }

    //    else if (collision.CompareTag("Chicken"))
    //    {
    //        ChickenSpawnerScript.chickenAnimalNo--;
    //        SceneManager.LoadScene(4);
    //        Destroy(collision.gameObject);

    //        charPosition = this.transform.position;
    //    }

    //    else if (collision.CompareTag("Monkey"))
    //    {
    //        MonkeySpawnerScript.monkeyAnimalNo--;
    //        SceneManager.LoadScene(5);
    //        Destroy(collision.gameObject);

    //        charPosition = this.transform.position;
    //    }

    //    //Destroy(collision.gameObject);

    //    //charPosition = this.transform.position;
    //}


}
