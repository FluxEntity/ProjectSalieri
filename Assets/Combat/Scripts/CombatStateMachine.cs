using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CombatStateMachine : MonoBehaviour {

    public Button Engage;
    public Button Tactic;
    public Button Interact;
    public Button Item;
    public Transform enemyAttackHandler;

    public enum states
    {
        START,
        PLAYERTURNSTART,
        PLAYERCHOOSING,
        PLAYERACTION,
        ENEMYTURNSTART,
        ENEMYCHOOSING,
        ENEMYACTION,
        LOSE,
        WIN
    }

    public static states currentState;

	// Use this for initialization
	void Start () {

        EventSystem.current.SetSelectedGameObject(null);
        currentState = states.START;
		
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(currentState);
        switch(currentState)
        {
            case (states.START):
                currentState = states.PLAYERTURNSTART;
                break;
            case (states.PLAYERTURNSTART):
                enableUI();
                currentState = states.PLAYERCHOOSING;
                break;
            case (states.PLAYERCHOOSING):
                break;
            case (states.PLAYERACTION):
                disableUI();
                EnemyAttack();
                break;
            case (states.ENEMYCHOOSING):
                //Setup Battle Function
                break;
            case (states.ENEMYACTION):
                //Setup Battle Function
                break;
            case (states.LOSE):
                //Setup Battle Function
                break;
            case (states.WIN):
                //Setup Battle Function
                break;
        }

    }

    public void enableUI()
    {
        Engage.interactable = true;
        Item.interactable = true;
        Interact.interactable = true;
        Tactic.interactable = true;
        Engage.Select();
    }

    public void disableUI()
    {
        Engage.interactable = false;
        Item.interactable = false;
        Interact.interactable = false;
        Tactic.interactable = false;
    }

    public void playerAttack()
    {
        currentState = states.PLAYERACTION;

    }
    public void EnemyAttack()
    {
        Instantiate(enemyAttackHandler);
        currentState = states.ENEMYACTION;
    }
}
