using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units
{
    public UnitsBase Base { get; set; }
    //int level;

    public int HP { get; set; }

    public List<Move> Moves { get; set; }

    public Units(UnitsBase aBase /*,int pLevel*/)
    {
        Base = aBase;
        //level = pLevel;

        HP = Base.MaxHP;

        // Generate Moves
        Moves = new List<Move>();
        foreach(var move in Base.LearnableMoves)
        {
            //if (move.Level <= level)
            //    Moves.Add(new Move(move.Base));
            Moves.Add(new Move(move.Base));

            if (Moves.Count >= 4)
                break;
        }
    }

    //public int Attack
    //{
    //    get { return Mathf.FloorToInt((Base.Attack * level) / 100f) + 5};
    //}    
}
