using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*  Documention on the Game Manager
 * 
 *  The Game Manager is an overarching class that handles data management and GUIs.
 *  Accessed by a lot of different elements, each of the variables/functions will be explained below.
 *  
 *  =============================================================
 *  
 *  Variables
 *  
 *  paused - Determines if the game is paused in any way or form. Restricts the player from moving.
 *  pauseMenu - Shows if the pause screen is showing.
 *  dialogue - A special variant of paused that is used when the player enters conversation with an NPC.
 *  
 *  playerDestination - An X-Y coordinate that determines where the player will first appear after transitioning scenes.
 *  playerScene - The scene that the player is currently occupying.
 *  
 *  =============================================================
 *  
 *  Functions
 *  
 *  LoadMapArea(string) - Loads a scene from the overworld. The input is the name of the scene to be loaded.
 *  TogglePauseMenu() - Show/Hides the pause menu.
 *  
 */
public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public Transform gamePauseMenu;

    private bool paused;
    private bool pauseMenu;
    private bool dialogue;

    private string playerScene;
    private Vector2 playerDestination;

    public bool Paused { get; set; }
    public bool PauseMenu { get; set; }
    public bool InDialogue { get; set; }
    public string PlayerScene { get; set; }
    public Vector2 PlayerDestination { get; set; }

    // Initiallizes the Game Manager. All other accesses will use this particular instance.
    void Awake () {
        if (instance == null)
        { instance = this; }
        else if (instance != this)
        { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}
    
    public void SaveAllInformation()
    {
        PlayerPrefs.SetInt("SAVEEXISTS", 1);
        PlayerPrefs.SetString("PLAYERSCENE", GameInformation.PlayerScene);

        PPSerialization.Save("PLAYERCLASS", GameInformation.PlayerClass);
        PlayerPrefs.SetInt("PLAYERLEVEL", GameInformation.PlayerLevel);
        PlayerPrefs.SetString("PLAYERNAME", GameInformation.PlayerName);
        PlayerPrefs.SetInt("HEALTH", GameInformation.Health);
        PlayerPrefs.SetInt("ATTACK", GameInformation.Attack);
        PlayerPrefs.SetInt("DODGE", GameInformation.Dodge);
        PlayerPrefs.SetInt("WILLPOWER", GameInformation.Willpower);
    }
    public void LoadAllInformation()
    {
        GameInformation.SaveExists = PlayerPrefs.GetInt("SAVEEXISTS");
        GameInformation.PlayerScene = PlayerPrefs.GetString("PLAYERSCENE");

        GameInformation.PlayerClass = (BaseCharacterClass)PPSerialization.Load("PLAYERCLASS");
        GameInformation.PlayerLevel = PlayerPrefs.GetInt("PLAYERLEVEL");
        GameInformation.PlayerName = PlayerPrefs.GetString("PLAYERNAME");
        GameInformation.Health = PlayerPrefs.GetInt("HEALTH");
        GameInformation.Attack = PlayerPrefs.GetInt("ATTACK");
        GameInformation.Dodge = PlayerPrefs.GetInt("DODGE");
        GameInformation.Willpower = PlayerPrefs.GetInt("WILLPOWER");
    }
    public void LoadSaveFile()
    {
        LoadAllInformation();
        LoadMapArea(GameInformation.PlayerScene);
    }
    public void LoadMapArea(string map)
    {
        SceneManager.LoadScene(map, LoadSceneMode.Single);
        GameInformation.PlayerScene = map;
    }

    public void TogglePauseMenu()
    {
        if (PauseMenu)
        { Instantiate(gamePauseMenu); }
        else { Destroy(FindObjectOfType<TestGUI>().gameObject); }
    }
}
