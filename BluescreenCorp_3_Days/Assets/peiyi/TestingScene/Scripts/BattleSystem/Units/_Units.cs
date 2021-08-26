using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Units
{
    public _UnitsBase Base { get; set; }
    public int Level { get; set; }

    public int HP { get; set; }

    public List<_Move> Moves { get; set; }

    public _Units(_UnitsBase aBase) 
    {
        Base = aBase;
        HP = MaxHP;

        //Generate Moves
        Moves = new List<_Move>();
        foreach (var move in Base.LearnableMoves)
        {
            /*******Use bool checking to add new moves***********/
            if(move.level <= Level)
            {
                Moves.Add(new _Move(move.Base));
            }

            if(Moves.Count >=4)
            {
                break;
            }
        }
    }

    public UnitTypes UnitTypes
    {
        get{ return Base.UnitTypes; }
    }

    public int Attack
    {
        get { return Base.Attack; }
    }

    public int MaxHP
    {
        get { return Base.MaxHP; }
    }

    public bool TakeDamage(_Move move, _Units attacker)
    {
        //float modifiers = Random.Range(0.85f, 1f);
        //int damage = Mathf.FloorToInt(move.Base.Power * modifiers);
        int damage = move.Base.Power;

        HP -= damage;

        if(HP <= 0)
        {
            HP = 0;
            return true;
        }

        return false;
    }

    public _Move GetRandomMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }
}
