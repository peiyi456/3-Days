using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _BattleUnit : MonoBehaviour
{
    [SerializeField] _UnitsBase _base;
    //[SerializeField] int level;
    //[SerializeField] bool isPlayerUnit;

    public _Units units { get; set; }

    public void Setup()
    {
        units = new _Units(_base);

        //if(isPlayerUnit)
        //{
        //    GetComponent<Image>
        //}

        GetComponent<Image>().sprite = units.Base.UnitSprite; 
    }
}
