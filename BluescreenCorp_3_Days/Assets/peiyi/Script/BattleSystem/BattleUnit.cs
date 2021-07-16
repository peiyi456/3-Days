using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] AnimalBase _base;
    [SerializeField] int level;
    [SerializeField] string[] tags = new string[] { "Duck", "Chicken", "Monkey" };

    [SerializeField] PlayerBase _PlayerBase;

    public Animal Animal { get; set; }

    public Player Player { get; set; }

    //[SerializeField] UnitsBase _base;
    ////[SerializeField] int level;

    //public Units units { get; set; }

    //public void Setup()
    //{
    //    units = new Units(_base);
    //    GetComponent<Image>().sprite = units.Base.Sprite;
    //}

    private void Update()
    {
        //_base = BattleScene.thisAnimal;
    }

    public void AnimalSetup()
    {
        _base = GameManager.instance.thisAnimal;

        Animal = new Animal(_base);

        GetComponent<Image>().sprite = Animal.Base.AnimalSprite;
    }

    public void PlayerSetup()
    {

        Player = new Player(_PlayerBase);

        GetComponent<Image>().sprite = Player.Base.PlayerSprite;
    }
}
