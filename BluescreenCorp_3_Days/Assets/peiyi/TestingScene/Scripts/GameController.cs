using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Battle, RunFromBattle }

public class GameController : MonoBehaviour
{
    [SerializeField] TriggerBattle triggerBattle;
    [SerializeField] _BattleSystem battleSystem;
    [SerializeField] Camera worldCamera;
    [SerializeField] GameObject worldScene;

    GameState state;

    // Start is called before the first frame update
    void Start()
    {
        triggerBattle.onTriggerBattle += StartBattle;
        battleSystem.OnBattleOver += EndBattle;
    }

    void StartBattle()
    {
        state = GameState.Battle;
        battleSystem.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
        worldScene.gameObject.SetActive(false);

        battleSystem.StartBattle();
    }

    void EndBattle(bool won)
    {
        state = GameState.FreeRoam;
        battleSystem.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
        worldScene.gameObject.SetActive(true);


        //GameManager.instance.isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == GameState.FreeRoam)
        {
            

            //triggerBattle.HandleUpdate();
            //GameManager.instance.isPause = false;
        }

        else if(state == GameState.Battle)
        {
            battleSystem.HandleUpdate();
            //GameManager.instance.isPause = true;
        }

        if(battleSystem.state == _BattleState.RunFromBattle)
        {
            battleSystem.state = _BattleState.Start;
            state = GameState.FreeRoam;
            battleSystem.gameObject.SetActive(false);
            worldCamera.gameObject.SetActive(true);
            worldScene.gameObject.SetActive(true);
            //GameManager.instance.isPause = false;
        }
        Debug.Log(state);
    }
}
