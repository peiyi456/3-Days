﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum _BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy}

public class _BattleSystem : MonoBehaviour
{
    [SerializeField] _BattleUnit playerUnit;
    [SerializeField] _BattleUnit enemyUnit;
    [SerializeField] _BattleHUD playerHUD;
    [SerializeField] _BattleHUD enemyHUD;
    [SerializeField] _BattleDialogBox dialogBox;

    _BattleState state;
    int currentAction;
    int currentMove;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHUD.SetData(playerUnit.units);
        enemyHUD.SetData(enemyUnit.units);

        dialogBox.SetMoveNames(playerUnit.units.Moves);

        yield return dialogBox.TypeDialog($"A wild {enemyUnit.units.Base.Name} appeared.");
        //yield return new WaitForSeconds(1f);

        PlayerAction();
    }

    void PlayerAction()
    {
        state = _BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose an action."));
        dialogBox.EnableActionSelector(true);
    }

    void PlayerMove()
    {
        state = _BattleState.PlayerMove;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);  
    }

    IEnumerator PerformPlayerMove()
    {
        state = _BattleState.Busy;

        var move = playerUnit.units.Moves[currentMove];
        yield return dialogBox.TypeDialog($"{playerUnit.units.Base.Name} used {move.Base.MoveName}");

        //yield return new WaitForSeconds(1f);

        bool isFainted = enemyUnit.units.TakeDamage(move, playerUnit.units);
        yield return enemyHUD.UpdateHP();

        if(isFainted)
        {
            yield return dialogBox.TypeDialog($"{enemyUnit.units.Base.Name} fainted");
        }
        else
        {
            StartCoroutine(EnemyMove());
        }

    }

    IEnumerator EnemyMove()
    {
        state = _BattleState.EnemyMove;

        var move = enemyUnit.units.GetRandomMove();
        yield return dialogBox.TypeDialog($"{enemyUnit.units.Base.Name} used {move.Base.MoveName}");

        //yield return new WaitForSeconds(1f);

        bool isFainted = playerUnit.units.TakeDamage(move, playerUnit.units);
        yield return playerHUD.UpdateHP();

        if (isFainted)
        {
            yield return dialogBox.TypeDialog($"{enemyUnit.units.Base.Name} fainted");
        }
        else
        {
            PlayerAction();
        }
    }

    private void Update()
    {
        if(state == _BattleState.PlayerAction)
        {
            HandleActionSelector();
        }

        else if(state == _BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }
    }

    private void HandleActionSelector()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if(currentAction < 1)
            {
                ++currentAction;
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (currentAction > 0)
            {
                --currentAction;
            }
        }

        dialogBox.UpadateActionSelection(currentAction);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentAction == 0)
            {
                // Fight
                PlayerMove();
            }

            else if (currentAction == 1)
            {
                // Run

            }
        }
    }

    private void HandleMoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentMove < playerUnit.units.Moves.Count - 1)
            {
                ++currentMove;
            }
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (currentMove > 0)
            {
                --currentMove;
            }
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (currentMove < playerUnit.units.Moves.Count - 2)
            {
                currentMove += 2;
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (currentMove > 1)
            {
                currentMove -= 2;
            }
        }

        dialogBox.UpdateMoveSelection(currentMove, playerUnit.units.Moves[currentMove]);

        if(Input.GetKeyDown(KeyCode.E))
        {
            dialogBox.EnableMoveSelector(false);
            dialogBox.EnableDialogText(true);
            StartCoroutine(PerformPlayerMove());
        }
    }
}
