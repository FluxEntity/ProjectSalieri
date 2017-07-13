using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameManager gameManager;

    public GameObject dialogueBox;
    public Text dialogueText;
    public Text dialogueOption;

    public TextAsset textFile;
    public string[] textLines;

    public Dialogue dialogue;

    public int currentChar;
    public int currentLine;
    public int endLine;
    public int currentNode;
    public int currentOption;

    public bool entryLine;


	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        dialogueBox.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (gameManager.InDialogue)
        {
            RunDialogue();
        }
    }


    public void DisplayTextBox()
    {
        gameManager.InDialogue = true;
        dialogueBox.SetActive(true);
    }

    public void HideTextBox()
    {
        gameManager.InDialogue = false;
        dialogueBox.SetActive(false);
    }

    public void RunDialogue()
    {
        if (dialogue.dialogueTree[currentNode].conversation[currentLine].Length > currentChar)
        {
            if (currentChar == 0) { dialogueText.text = ""; }
            dialogueText.text += dialogue.dialogueTree[currentNode].conversation[currentLine][currentChar];
            currentChar++;
        }
        
        //dialogueText.text = dialogue.dialogueTree[currentNode].conversation[currentLine];

        // Ongoing conversation before choice selection
        if (Input.GetKeyDown(KeyCode.Return) && currentLine != dialogue.dialogueTree[currentNode].conversation.Count - 1 && !entryLine)
        {
            if (currentChar == dialogue.dialogueTree[currentNode].conversation[currentLine].Length)
            {
                currentLine++;
                currentChar = 0;
            }
        }

        // If available, choice is offered at the end of the node
        else if (currentLine == dialogue.dialogueTree[currentNode].conversation.Count - 1)
        {
            if (currentChar == dialogue.dialogueTree[currentNode].conversation[currentLine].Length)
            {
                SelectChoice();
            }

        }

        if (entryLine)
        {
            entryLine = false;
        }
    }

    public void SelectChoice()
    {
        if (dialogue.dialogueTree[currentNode].options.Count == 0)
        {
            
            if (Input.GetKeyDown(KeyCode.Return) && entryLine == false)
            {
                gameManager.Paused = false;
                HideTextBox();
            }
        }
        else
        {
            dialogueOption.text = dialogue.dialogueTree[currentNode].options[currentOption].text;
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (currentOption == dialogue.dialogueTree[currentNode].options.Count - 1)
                {
                    currentOption = 0;
                }
                else { currentOption++; }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (currentOption == 0)
                {
                    currentOption = dialogue.dialogueTree[currentNode].options.Count - 1;
                }
                else { currentOption--; }
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                currentNode = dialogue.dialogueTree[currentNode].options[currentOption].destNodeID;
                currentChar = 0;
                currentLine = 0;
                currentOption = 0;
                dialogueOption.text = "";
                entryLine = true;
            }
        }
        
    }
}
