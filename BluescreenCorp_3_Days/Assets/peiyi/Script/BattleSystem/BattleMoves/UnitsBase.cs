using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Units", menuName = "Units/Create new units")]
public class UnitsBase : ScriptableObject
{
    [SerializeField] string UnitsName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite UnitsSprite;
    [SerializeField] UnitsType type;

    //Base Stats
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    //[SerializeField] int defense;
    //[SerializeField] int spAttack;
    //[SerializeField] int spDefense;
    //[SerializeField] int speed;

    [SerializeField] List<LearnableMove> learnableMoves;

    //public string GetName()
    //{
    //    return name;
    //}

    [System.Serializable]
    public class LearnableMove
    {
        [SerializeField] MoveBase moveBase;
        //[SerializeField] int level;

        public MoveBase Base
        {
            get { return moveBase; }
        }

        //public int Level
        //{
        //    get { return level; }
        //}
    }

    public enum UnitsType
    {
        Player,
        Duck,
        Monkey,
    }

    public string Name
    {
        get { return UnitsName; }
    }

    public string Description
    {
        get { return description; }
    }

    public Sprite Sprite
    {
        get { return UnitsSprite; }
    }

    public int MaxHP
    {
        get { return maxHP; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public List<LearnableMove> LearnableMoves
    {
        get { return learnableMoves; }
    }
}
