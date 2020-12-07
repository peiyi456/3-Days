using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMove", menuName = "Player/Create new player status")]
public class PlayerBase : ScriptableObject
{
    [SerializeField] string PlayerName;

    [SerializeField] Sprite playerSprite;


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
        [SerializeField] PlayerMoveBase moveBase;
        //[SerializeField] int level;

        public PlayerMoveBase Base
        {
            get { return moveBase; }
        }

        //public int Level
        //{
        //    get { return level; }
        //}
    }

    public string Name
    {
        get { return PlayerName; }
    }

    //public string Description
    //{
    //    get { return description; }
    //}

    public Sprite PlayerSprite
    {
        get { return playerSprite; }
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
