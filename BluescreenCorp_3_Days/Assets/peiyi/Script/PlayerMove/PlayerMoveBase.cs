using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMove", menuName = "Player/Create new move")]
public class PlayerMoveBase : ScriptableObject
{
    [SerializeField] string moveName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

    //[SerializeField] List<LearnableMove> learnableMoves;

    //[System.Serializable]
    //public class LearnableMove
    //{
    //    [SerializeField] PlayerMoveBase moveBase;
    //    [SerializeField] int level;

    //    public PlayerMoveBase Base
    //    {
    //        get { return moveBase; }
    //    }

    //    public int Level
    //    {
    //        get { return level; }
    //    }
    //}

    public string MoveName
    {
        get { return moveName; }
    }

    public string Description
    {
        get { return description; }
    }

    public int Power
    {
        get { return power; }
    }

    public int Accuracy
    {
        get { return accuracy; }
    }

    public int PP
    {
        get { return pp; }
    }

    //public List<LearnableMove> LearnableMoves
    //{
    //    get { return learnableMoves; }
    //}
}
