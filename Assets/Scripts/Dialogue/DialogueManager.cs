using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameManager gameManager;

    public GameObject dialogueBox;
    public Text dialogueText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endLine;


	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        dialogueBox.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (gameManager.InDialogue)
        {
            dialogueText.text = textLines[currentLine];
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentLine++;
        }
        if (currentLine > endLine)
        {
            dialogueBox.SetActive(false);
            gameManager.InDialogue = false;
        }
    }

    public void AcceptText()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        currentLine = 0;
        endLine = textLines.Length - 1;
    }

    public void DisplayTextBox()
    {
        gameManager.InDialogue = true;
        dialogueBox.SetActive(true);
    }
}
