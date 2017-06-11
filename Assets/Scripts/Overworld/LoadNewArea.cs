using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

    public string levelToLoad;
    public Vector2 destination;
    public string requiredDirection;

    private PlayerController player;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Called when an object with a Collider bumps into this object's space
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && (requiredDirection == player.Direction() || requiredDirection == ""))
        {
            gameManager.PlayerDestination = destination;
            gameManager.LoadMapArea(levelToLoad);
        }

    }
}
