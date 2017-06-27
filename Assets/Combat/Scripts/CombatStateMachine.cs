using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CombatStateMachine : MonoBehaviour {

    public GameObject actionPanel;
    public GameObject selectTargetPanel;
    public GameObject graphicPanel;
    public Transform enemyAttackHandler;
    public Transform playerAttackHandler;
    public GameObject prioUI;
    public List<Enemy> enemyList;
    public Enemy selectedEnemy;
    public int playerHP;
    public int playerWL;
    public int playerMaxHP;
    public int playerMaxWL;

    public enum action
    {
        ATTACK,
        TACTICS,
        INTERACT,
        ITEMS
    }

    public action playerAction;

    public enum State
    {
        START,
        UPDATEGUI,
        PLAYERTURNSTART,
        PLAYERCHOOSING,
        PLAYERACTION,
        ENEMYTURNSTART,
        ENEMYCHOOSING,
        ENEMYACTION,
        ENEMYDONE,
        LOSE,
        WIN
    }

    public static State currentState;

    //INITIALIZE BATTLE
	void Start () {
        playerMaxHP = 50;
        playerMaxWL = 30;
        playerHP = 50;
        playerWL = 30;
        enemyList = new List<Enemy>();
        GameObject[] tempList = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < tempList.Length; i++)
        {
            enemyList.Add(tempList[i].GetComponent<Enemy>());
        }
        EventSystem.current.SetSelectedGameObject(null);
        selectTargetPanel.SetActive(false);
        currentState = State.START;
		
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(currentState);
        switch(currentState)
        {
            //START loads and organizes all necessary starting prefabs/objects
            case (State.START):
                currentState = State.UPDATEGUI;
                break;
            
            //UPDATEGUI Makes the GUI up to date with current available enemies and items
            case (State.UPDATEGUI):
                Button[] enemyButtons = selectTargetPanel.GetComponentsInChildren<Button>();
                for (int i = 0; i < enemyButtons.Length; i++)
                {
                    if (i < enemyList.Count)
                    {
                        enemyButtons[i].GetComponentInChildren<Text>().text = enemyList[i].alias;
                        enemyList[i].myButton = enemyButtons[i];
                    }
                    else
                    {
                        enemyButtons[i].gameObject.SetActive(false);
                    }
                }
                currentState = State.PLAYERTURNSTART;
                break;
            
            //PLAYERTURNSTART performs setup for beginning of player's turn
            case (State.PLAYERTURNSTART):
                selectTargetPanel.SetActive(false);
                EnableUI();
                currentState = State.PLAYERCHOOSING;
                break;
            
            //PLAYERCHOOSING waits for player to choose course of action
            case (State.PLAYERCHOOSING):
                break;

            //PLAYERACTION waits for player to perform chosen action
            case (State.PLAYERACTION):
                DisableUI();
                break;
            
            //ENEMYTURNSTART beginning of enemy turn
            case (State.ENEMYTURNSTART):
                bool ready = true;
                foreach (Enemy e in enemyList)
                {
                    if (e.currentState != Enemy.State.IDLE)
                    {
                        ready = false;
                    }
                }
                if (ready) { currentState = State.ENEMYCHOOSING; }
                break;

            //ENEMYCHOOSING waits for enemies to choose course of action
            case (State.ENEMYCHOOSING):
                currentState = State.ENEMYACTION;
                EnemyAttack();
                break;
            
            //ENEMYACTION waits for enemies to perform actions
            case (State.ENEMYACTION):
                break;
          
            //ENEMYDONE signals the end of enemy turn
            case (State.ENEMYDONE):
                currentState = State.PLAYERTURNSTART;
                break;

            //LOSE signals end of battle with a loss
            case (State.LOSE):
                break;
   
            //WIN signals end of battle with a win
            case (State.WIN):
                break;
        }

    }

    public void EnableUI()
    {
        EventSystem.current.SetSelectedGameObject(null);
        actionPanel.SetActive(true);
        actionPanel.GetComponentInChildren<Button>().Select();
    }

    public void DisableUI()
    {
    
    }

    public void EngageUI()
    {
        playerAction = action.ATTACK;
        actionPanel.SetActive(false);
        selectTargetPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        selectTargetPanel.GetComponentInChildren<Button>().Select();
    }
    public void ActionUI()
    {
        actionPanel.SetActive(true);
        selectTargetPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        actionPanel.GetComponentInChildren<Button>().Select();
    }

    public void SetPriorUI(GameObject panel)
    {
        prioUI = panel;
    }

    public void ToPriorUI()
    {
        selectTargetPanel.SetActive(false);
        actionPanel.SetActive(false);
        prioUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        prioUI.GetComponentInChildren<Button>().Select();

    }

    public void EnemyAttack()
    {
        actionPanel.SetActive(false);
        selectTargetPanel.SetActive(false);
        Instantiate(enemyAttackHandler);
        currentState = State.ENEMYACTION;
    }

    public void SelectTarget(Button selectedButton)
    {
        Button[] enemyButtons = selectTargetPanel.GetComponentsInChildren<Button>();
        for(int i = 0; i < enemyButtons.Length; i++)
        {
            if(selectedButton == enemyButtons[i])
            {
                selectedEnemy = enemyList[i];
            }
        }
        actionPanel.SetActive(false);
        selectTargetPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        if (playerAction == action.ATTACK)
        {
            Instantiate(playerAttackHandler);
        }
        currentState = State.PLAYERACTION;
    }

    public void SetState(State state)
    {
        currentState = state;
    }
}
