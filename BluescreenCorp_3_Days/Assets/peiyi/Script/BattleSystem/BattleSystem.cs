using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy};

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleDialogBox dialogBox;

    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit animalUnit;
    [SerializeField] BattleHUD playerHud;
    [SerializeField] BattleHUD animalHud;

    BattleState state;
    int currentAction;
    int currentMove;

    [SerializeField] GameObject combatScene;
    [SerializeField] GameObject mainScene;
    [SerializeField] Camera mainCamera;

    public Animator playerUnitAnim;
    public Animator animalUnitAnim;

    bool isDead;

    public static bool isDrop;

    // Start is called before the first frame update
    void Start()
    {

        //StartCoroutine(SetupBattle());
        isDrop = false;
        //anim = GetComponent<Animator>();
    }

    

    public IEnumerator SetupBattle()
    {
        playerUnit.PlayerSetup();
        animalUnit.AnimalSetup();
        playerHud.PlayerSetData(playerUnit.Player);
        animalHud.AnimalSetData(animalUnit.Animal);

        dialogBox.SetMoveName(playerUnit.Player.Moves);

        yield return dialogBox.TypeDialog($"A wild {animalUnit.Animal.Base.Name} is here.");

        //playerUnit.Setup();
        //playerHud.SetData(playerUnit.units);
        //animalUnit.Setup();
        //animalHud.SetData(animalUnit.units);
        //yield return dialogBox.TypeDialog($"A wild {animalUnit.units.Base.Name} is here.");
        yield return new WaitForSeconds(1f);

        PlayerAction();

    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose an action."));
        dialogBox.EnableActionSelector(true); 
    }

    void PlayerMove()
    {
        state = BattleState.PlayerMove;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);
    }

    private void Update()
    {
        if (GameManager.instance.isPause == true)
        {
            if (GameManager.instance.isBattle == true)
            {
                if (state == BattleState.PlayerAction)
                {
                    HandleActionSelection();
                }
                else if (state == BattleState.PlayerMove)
                {
                    HandleMoveSelection();
                }

                if (isDead)
                {
                    GameManager.instance.isPause = false;
                    StartCoroutine(AnimalFainted());
                    GameManager.instance.isBattle = false;
                }
            }
            else
            {
                StartCoroutine(SetupBattle());
                GameManager.instance.isBattle = true;
            }
        }
    }

    void HandleActionSelection()
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
            if(currentAction > 0)
            {
                --currentAction;
            }
        }

        dialogBox.UpdateActionSelection(currentAction);

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(currentAction == 0)
            {
                //Fight
                PlayerMove();
            }

            else if (currentAction == 1)
            {
                //Run
                combatScene.SetActive(false);
                mainScene.SetActive(true);
                //SceneManager.LoadScene(2);
                isDrop = false;
            }
        }
    }

    void HandleMoveSelection()
    {
        //if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A))
        //{
        //    if (currentMove < playerUnit.Player.Moves.Count - 1)
        //    {
        //        ++currentMove;
        //    }
        //}
        //else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D))
        //{
        //    if (currentMove > 0)
        //    {
        //        --currentMove;
        //    }
        //}
        //else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        //{
        //    if (currentMove < playerUnit.Player.Moves.Count - 2)
        //    {
        //        currentMove += 2;
        //    }
        //}
        //else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        //{
        //    if (currentMove > 1)
        //    {
        //        currentMove -= 2;
        //    }
        //}

        //dialogBox.UpdateMoveSelection(currentMove, playerUnit.Player.Moves[currentMove]);
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (currentMove < 1)
            {
                ++currentMove;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (currentMove > 0)
            {
                --currentMove;
            }
        }

        dialogBox.UpdateMoveSelection(currentMove);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentMove == 0)
            {
                //Animal straight die
                //anim.Play("Battle_Punch");
                dialogBox.EnableMoveSelector(false);
                dialogBox.EnableDialogText(true);
                StartCoroutine(PerfromPlayerMove());
                isDrop = true;

            }

            else if (currentMove == 1)
            {
                //No Action
            }
        }
    }

    IEnumerator PerfromPlayerMove()
    {
        state = BattleState.Busy;

        //anim.Play("Battle_Punch");
        yield return dialogBox.TypeDialog($"{playerUnit.Player.Base.Name} used punch");

        yield return new WaitForSeconds(1f);

        playerUnitAnim.Play("Battle_Punch");

        yield return new WaitForSeconds(1f);

        animalUnit.Animal.HP = 0;
        yield return animalHud.UpdateHP();

        yield return dialogBox.TypeDialog($"{animalUnit.Animal.Base.Name} died");

        isDead = true;
        //yield return new WaitForSeconds(1f);
        //playerUnitAnim.Play("Battle_Punch");
        //animalUnitAnim.Play("Animal_Fainted");

        //yield return new WaitForSeconds(1f);
    }

    IEnumerator AnimalFainted()
    {
        state = BattleState.Busy;
        //animalUnitAnim.Play("Animal_Fainted");
        yield return new WaitForSeconds(1f);
        mainScene.SetActive(true);
        //mainCamera.gameObject.SetActive(true);
        combatScene.SetActive(false);
        //SceneManager.LoadScene(2);
        //Debug.Log("Get feather, meat");
    }
}
