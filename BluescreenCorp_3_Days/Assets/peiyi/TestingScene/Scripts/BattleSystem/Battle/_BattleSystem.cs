using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum _BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy, RunFromBattle}

public class _BattleSystem : MonoBehaviour
{
    [SerializeField] Slider playerHP;
    [SerializeField] _BattleUnit playerUnit;
    [SerializeField] _BattleUnit enemyUnit;
    [SerializeField] _BattleHUD playerHUD;
    [SerializeField] _BattleHUD enemyHUD;
    [SerializeField] _BattleDialogBox dialogBox;

    public event Action<bool> OnBattleOver;

    public _BattleState state;
    int currentAction;
    int currentMove;

    // Start is called before the first frame update
    public void StartBattle()
    {
        StartCoroutine(SetupBattle());
        currentAction = 0;
        currentMove = 0;
        GameManager.instance.isPause = true;
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

        playerUnit.PlayAttackAnimation();
        yield return new WaitForSeconds(1f);

        enemyUnit.PlayHitAnimation();

        bool isFainted = enemyUnit.units.TakeDamage(move, playerUnit.units);
        yield return enemyHUD.UpdateHP();

        if(isFainted)
        {
            /****HP thing****/
            playerHP.value = playerUnit.units.HP;
            GameManager.instance.enemyFainted = true;
            yield return dialogBox.TypeDialog($"{enemyUnit.units.Base.Name} fainted");
            enemyUnit.PlayFaintAnimation();

            yield return new WaitForSeconds(2f);
            OnBattleOver(true);
            PlayerStatusManager.instance.PlayerStamina.value -= 20f;
            GameManager.instance.isPause = false;
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

        enemyUnit.PlayAttackAnimation();
        yield return new WaitForSeconds(1f);

        playerUnit.PlayHitAnimation();
        bool isFainted = playerUnit.units.TakeDamage(move, playerUnit.units);
        yield return playerHUD.UpdateHP();

        if (isFainted)
        {
            yield return dialogBox.TypeDialog($"{playerUnit.units.Base.Name} fainted");
            playerUnit.PlayFaintAnimation();

            yield return new WaitForSeconds(2f);
            OnBattleOver(false);
            GameManager.instance.isPause = false;
        }
        else
        {
            PlayerAction();
        }
    }

    public void HandleUpdate()
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
                //RunFromBattle();
                OnBattleOver(false);
                //state = _BattleState.RunFromBattle;
                GameManager.instance.isPause = false;
                //Debug.Log(GameManager.instance.isPause);
            }
        }
    }

    void RunFromBattle()
    {
        state = _BattleState.Busy;
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
