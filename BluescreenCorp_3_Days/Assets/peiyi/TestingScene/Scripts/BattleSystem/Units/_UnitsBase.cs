using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitTypes { Animals, Player};

[CreateAssetMenu(fileName = "Units", menuName = "Units/Create new unit")]
public class _UnitsBase : ScriptableObject
{
    [SerializeField] string UnitName;
    [SerializeField] string UnitTag;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite unitSprite;


    //Base Stats
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    //[SerializeField] int defense;
    //[SerializeField] int spAttack;
    //[SerializeField] int spDefense;
    //[SerializeField] int speed;

    [SerializeField] UnitTypes unitTypes;

    [SerializeField] List<LearnableMove> learnableMoves;

    //public string GetName()
    //{
    //    return name;
    //}

    
    public string Name
    {
        get { return UnitName; }
    }

    public string Tag
    {
        get { return UnitTag; }
    }

    public string Description
    {
        get { return description; }
    }

    public Sprite UnitSprite
    {
        get { return unitSprite; }
    }

    public int MaxHP
    {
        get { return maxHP; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public UnitTypes UnitTypes
    {
        get { return unitTypes; }
    }

    public List<LearnableMove> LearnableMoves
    {
        get { return learnableMoves; }
    }

    [System.Serializable]
    public class LearnableMove
    {
        [SerializeField] _MoveBase moveBase;
        [SerializeField] int toolLevel;

        public _MoveBase  Base
        {
            get { return moveBase; }
        }

        public int level
        {
            get { return toolLevel; }
        }
    }


    
}


