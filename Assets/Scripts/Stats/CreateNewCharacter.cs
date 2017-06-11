using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewCharacter : MonoBehaviour {

    private GameManager gameManager;

    private BasePlayer newPlayer;
    private string playerName;
    private string classDescription;
    private bool classSelected = false;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        newPlayer = new BasePlayer();
        playerName = "";
        classDescription = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        GUI.skin.label.wordWrap = true;

        // Player Name
        GUI.BeginGroup(new Rect(50, 50, 200, 100));
        GUI.skin.textField.fontSize = 18;
        GUI.skin.label.fontSize = 18;
        GUI.Box(new Rect(0, 0, 200, 80), "");
        GUI.Label(new Rect(45, 10, 120, 30), "Player Name");
        playerName = GUI.TextField(new Rect(25, 40, 150, 30), playerName);
        GUI.EndGroup();

        SelectClass();

        // Create Character Button
        if (GUI.Button(new Rect(170, Screen.height - 70, 80, 30), "Create") && classSelected)
        {
            Finish();
        }
    }

    void SelectClass()
    {
        // Class Selection
        GUI.BeginGroup(new Rect(50, 170, 200, 500));
        GUI.skin.label.fontSize = 14;
        GUI.Box(new Rect(0, 0, 200, 200), "");
        GUI.Label(new Rect(20, 10, 100, 30), "Classes");
        if (GUI.Button(new Rect(10, 50, 80, 30), "Athlete"))
        {
            newPlayer.PlayerClass = new BaseAthleteClass();
            classDescription = newPlayer.PlayerClass.CharacterClassDescription;
            classSelected = true;
        }
        if (GUI.Button(new Rect(10, 90, 80, 30), "Engineer"))
        {
            newPlayer.PlayerClass = new BaseEngineerClass();
            classSelected = true;
            classDescription = newPlayer.PlayerClass.CharacterClassDescription;
        }
        GUI.EndGroup();

        // Class Description
        GUI.BeginGroup(new Rect(Screen.width * 1 / 2, 50, Screen.width * 1 / 2 - 50, 500));
        GUI.skin.label.alignment = TextAnchor.UpperRight;
        GUI.Label(new Rect(0, 0, Screen.width * 1 / 2 - 50, 100), classDescription);
        GUI.EndGroup();
    }
    
    public void Finish()
    {
        GameInformation.PlayerClass = newPlayer.PlayerClass;
        GameInformation.Health = newPlayer.PlayerClass.Health;
        GameInformation.Attack = newPlayer.PlayerClass.Attack;
        GameInformation.Dodge = newPlayer.PlayerClass.Dodge;
        GameInformation.Willpower = newPlayer.PlayerClass.Willpower;
        GameInformation.PlayerName = playerName;
        GameInformation.PlayerLevel = 1;
        gameManager.LoadMapArea("main");
    }
}
