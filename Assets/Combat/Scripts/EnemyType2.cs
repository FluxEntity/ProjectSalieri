using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyType2 : Enemy {

	// Use this for initialization
	void Start () {
        alias = "Mr. Worldwide";
        baseHP = 20;
        baseWL = 10;
        baseDMG = 3;
        baseDEF = 1;
        baseAGL = 1;
        baseRSL = 1;
        curHP = baseHP;
        curWL = baseWL;
        curDMG = baseDMG;
        curDEF = baseDEF;
        curAGL = baseAGL;
        curRSL = baseRSL;
        baseposition = transform.position;
        notemaps = new List<float[,]>();
        notemaps.Add(new float[,]{ 
            { 0.1f, 0, 0, 0, 0, 0, 1 / 4f },
            { 0, 0.1f, 0, 0, 0, 0, 1 / 4f },
            { 0, 0, 0.1f, 0, 0, 0, 1 / 4f },
            { 0, 0, 0, 0.1f, 0, 0, 1 / 4f },
            { 0.1f, 0, 0, 0, 0, 0.1f, 1 / 2f },
            { 0, 0, 0.1f, 0, 0.1f, 0, 1 / 2f },
            { 1, 0, 0, 0, 0, 0, 1 },
            { 0, 1, 1, 0, 0, 0, 1 },
            { 1, 0, 0, 1, 0, 0, 1 },
            { 0, 1, 0, 0, 1, 0, 1 },
            { 1f, 0, 0, 0.1f, 0, 0, 1 / 4f },
            { 0, 0, 0, 0, 0.1f, 0, 1 / 8f },
            { 0, 0, 0, 0, 0, 0.1f, 1 / 8f },
            { 0, 0, 0, 0, 0.1f, 0, 1 / 4f},
            { 0, 0, 0, 0.1f, 0, 0, 1 / 4f},
            { 0, 0, 0, 0, 0.1f, 0, 1 / 4f},
            { 0, 0, 0, 0.1f, 0, 0.1f, 1 / 4f},
            { 0, 0, 0, 0.1f, 0, 0.1f, 1 / 4f},
            { 0, 0, 0, 0.1f, 0, 0.1f, 1 / 4f} });

        notemaps.Add(new float[,] {
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f },
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f },
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f },
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f },
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f },
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f },
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f },
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f },
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f },
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f },
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f },
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f },
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f },
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f },
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f },
            {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 1/8f }});

}
	
	// Update is called once per frame
	void Update () {
        SelectionStatus();
        StateStatus();
    }
}
