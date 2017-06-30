using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour {

    public string alias;
    public int baseHP;
    public int curHP;
    public float floatHP;
    public int nextHP;
    public float HPdeficit;
    public int baseWL;
    public int curWL;
    public float floatWL;
    public int nextWL;
    public float WLdeficit;
    public int baseDMG;
    public int baseDEF;
    public int baseAGL;
    public int baseRSL;
    public int curDMG;
    public int curDEF;
    public int curAGL;
    public int curRSL;
    public List<float[,]> notemaps;
    public Button myButton;
    public float shakeAmount;
    public Vector3 baseposition;
    public Transform damageText;

    public enum State
    {
        IDLE,
        WAIT,
        CHOOSING,
        ACTING,
        TAKINGDAMAGE,
        DEAD
    }

    public State currentState;
    public State nextState;
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void StateStatus()
    {
        switch (currentState)
        {
            case (State.IDLE):
                break;
            case (State.TAKINGDAMAGE):
                if (floatHP > nextHP)
                {
                    //print("current HP: " + curHP + ", next HP: " + nextHP + ", HP deficit: " + HPdeficit);
                    if (floatHP - nextHP > HPdeficit / 2)
                    {
                        shakeAmount = Mathf.Min(0.5f, shakeAmount + 0.3f * Time.deltaTime);
                    }
                    else
                    {
                        shakeAmount = Mathf.Max(0, shakeAmount - 0.3f * Time.deltaTime);
                    }
                    transform.position = new Vector3(baseposition.x + shakeAmount * Mathf.Sin(Time.time * 40), transform.position.y);
                    //print("xposition: " + transform.position.x);
                    floatHP = Mathf.Max(floatHP - (HPdeficit * 2) * Time.deltaTime, nextHP);
                    curHP = (int)floatHP;
                    //print("current HP: " + curHP);

                }
                else
                {
                    currentState = State.IDLE;
                }
                break;
        }
    }

    public void SelectionStatus()
    {
        if (myButton != null && myButton.gameObject == EventSystem.current.currentSelectedGameObject)
        {
            GetComponentsInChildren<SpriteRenderer>()[1].color = new Color(1, 0.7f, 0.7f, 1);
            GetComponent<SpriteRenderer>().color = new Color(1, 0.7f, 0.7f, 1);
        }
        else
        {
            GetComponentsInChildren<SpriteRenderer>()[1].color = new Color(0, 0, 0, 0);
            GetComponent<SpriteRenderer>().color = new Color(1, 1f, 1f, 1);
        }
    }

    public void TakeDamage(int amount)
    {
        nextHP = (int)(curHP - (amount - amount * curDEF * 0.2));
        shakeAmount = 0;
        HPdeficit = curHP - nextHP;
        floatHP = curHP;
        Instantiate(damageText, transform.position, transform.rotation).GetComponentInChildren<Text>().text = HPdeficit.ToString();
        currentState = State.TAKINGDAMAGE;
    }

    public float[,] ChooseNoteMap()
    {
        return notemaps[Random.Range(0, notemaps.Count - 1)];
    }
}
