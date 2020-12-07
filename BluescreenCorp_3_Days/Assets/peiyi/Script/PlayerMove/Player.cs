using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public PlayerBase Base { get; set; }

    public int HP { get; set; }

    public List<PlayerMove> Moves { get; set; }

    //private Inventory inventory;

    //public void Awake()
    //{
    //    Base =
    //    inventory = new Inventory();
    //}

    public Player(PlayerBase aBase)
    {
        Base = aBase;
        HP = Base.MaxHP;

        Moves = new List<PlayerMove>();
        foreach (var move in Base.LearnableMoves)
        {
            //if (move.Level <= level)
            //    Moves.Add(new Move(move.Base));
            Moves.Add(new PlayerMove(move.Base));

            if (Moves.Count >= 4)
                break;
        }
    }
}
