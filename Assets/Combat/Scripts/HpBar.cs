using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{

    CombatStateMachine CSM;
    // Use this for initialization
    void Start()
    {
        CSM = GameObject.Find("BattleManager").GetComponent<CombatStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(Mathf.Max(0,((float)CSM.playerHP / CSM.playerMaxHP)), 1, 1);
    }
}
