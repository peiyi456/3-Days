using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitTypes { Animals, Player};

[CreateAssetMenu(fileName = "Units", menuName = "Units/Create new unit")]
public class _UnitsBase : ScriptableObject
{
    [Header("Details")]
    [SerializeField] bool isPlayer;
    [SerializeField] string UnitName;
    [SerializeField] string UnitTag;
    [SerializeField] Item dropItem;

    [TextArea]
    [SerializeField] string characteristics;
    [SerializeField] string appearIn;
    [SerializeField] Sprite unitSprite;
    [SerializeField] float rescalingUnitImageSize;


    [Header("Base Stats")]
    //Base Stats
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    //[SerializeField] int defense;
    //[SerializeField] int spAttack;
    //[SerializeField] int spDefense;
    //[SerializeField] int speed;

    [SerializeField] UnitTypes unitTypes;

    [Header("Learnable Moves")]
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

    public bool IsPlayer
    {
        get { return isPlayer; }
    }

    public Item DropItem
    {
        get { return dropItem; }
    }

    public string Characteristics
    {
        get { return characteristics; }
    }

    public string AppearIn
    {
        get { return appearIn; }
    }

    public Sprite UnitSprite
    {
        get { return unitSprite; }
    }

    public float RescaleImage
    {
        get { return rescalingUnitImageSize; }
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
        public _MoveBase moveBase;
        public int toolLevel;

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


