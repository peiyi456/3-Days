using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNewAttack : MonoBehaviour
{
    [SerializeField] _UnitsBase.LearnableMove punch;
    [SerializeField] _UnitsBase.LearnableMove bluntKnife;
    [SerializeField] _UnitsBase.LearnableMove bluntAxe;
    [SerializeField] _UnitsBase.LearnableMove lance;
    [SerializeField] _UnitsBase player;

    [SerializeField] bool isAddKnifeAttack;
    [SerializeField] bool isAddAxeAttack;
    [SerializeField] bool isAddLanceAttack;

    // Start is called before the first frame update
    void Start()
    {
        player.LearnableMoves.Clear();
        player.LearnableMoves.Add(punch);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.hasKnife)
        {
            if (isAddKnifeAttack == false)
            {
                player.LearnableMoves.Add(bluntKnife);
                Debug.Log("Add");
                isAddKnifeAttack = true;
            }
            
        }


        if(GameManager.instance.hasAxe)
        {
            if (isAddAxeAttack == false)
            {
                player.LearnableMoves.Add(bluntAxe);
                isAddAxeAttack = true;
            }
        }


        if (GameManager.instance.hasLance)
        {
            if (isAddLanceAttack == false)
            {
                player.LearnableMoves.Add(lance);
                isAddLanceAttack = true;
            }
        }

    }
}
