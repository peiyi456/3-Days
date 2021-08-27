using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "Animal/Create new animal")]
public class AnimalBase : ScriptableObject
{
    [SerializeField] string AnimalName;
    [SerializeField] string AnimalTag;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite animalSprite;


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
        [SerializeField] AnimalMoveBase moveBase;
        [SerializeField] int toolLevel;
    }

    public string Name
    {
        get { return AnimalName; }
    }

    public string Tag
    {
        get { return AnimalTag; }
    }

    public string Description
    {
        get { return description; }
    }

    public Sprite AnimalSprite
    {
        get { return animalSprite; }
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


