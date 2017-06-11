using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGUI : MonoBehaviour {

    private GameManager gameManager;
    public TextMesh text;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if (gameManager.PauseMenu)
        {
            GUI.BeginGroup(new Rect(20, 20, 200, 500));
            GUI.Box(new Rect(0, 0, 200, Screen.height - 50), "");
            GUI.skin.label.alignment = TextAnchor.UpperLeft;
            GUI.Label(new Rect(10, 10, 150, 30), GameInformation.PlayerName);
            GUI.Label(new Rect(10, 40, 150, 30), "Level - " + GameInformation.PlayerLevel.ToString());
            GUI.Label(new Rect(10, 70, 150, 30), "Health - " + GameInformation.Health.ToString());
            GUI.Label(new Rect(10, 100, 150, 30), "Attack - " + GameInformation.Attack.ToString());
            GUI.Label(new Rect(10, 130, 150, 30), "Dodge - " + GameInformation.Dodge.ToString());
            GUI.Label(new Rect(10, 160, 150, 30), "Willpower - " + GameInformation.Willpower.ToString());
            GUI.EndGroup();

            if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 50, 80, 30),"Save"))
            {
                gameManager.SaveAllInformation();
            }
        }
    }
}
