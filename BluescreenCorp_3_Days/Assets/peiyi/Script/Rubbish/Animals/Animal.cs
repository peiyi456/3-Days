using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    public AnimalBase Base { get; set; }
    
    public int HP { get; set; }

    public Animal(AnimalBase aBase)
    {
        Base = aBase;
        HP = Base.MaxHP;

    }

    public int Attack
    {
        get { return Mathf.FloorToInt((Base.Attack / 100f) + 5); }
    }

    //public int MaxHP
    //{
    //    get { return Mathf.FloorToInt((Base.Attack / 100f) + 10); }
    //}

    //public bool TakeDamage(PlayerMove move, Player attacker)
    //{
    //    int damage = 5;

    //    HP -= damage;
    //    if (HP <= 0)
    //    {
    //        HP = 0;
    //        return true;
    //    }

    //    return false;
    //}
}
