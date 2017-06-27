using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackHandler : MonoBehaviour {

    public Transform swordAttack;
    CombatStateMachine CSM;
    public Enemy enemy;
    // Use this for initialization
    void Start () {
        CSM = GameObject.Find("BattleManager").GetComponent<CombatStateMachine>();
        enemy = CSM.selectedEnemy;
        swordAttack = Instantiate(swordAttack, enemy.gameObject.transform.position, swordAttack.transform.rotation);
        CSM.graphicPanel.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (swordAttack == null)
        {
            CSM.SetState(CombatStateMachine.State.ENEMYTURNSTART);
            Destroy(gameObject);
        }
	}
}
