using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    private GameManager gameManager;

    private PlayerController thePlayer;
    private CameraController theCamera;

	// A start point will exist in every player-accessible map area.
    // Will adjust itself to the recorded player destination as defined in the previous scene.

	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        this.transform.position = gameManager.PlayerDestination;
        thePlayer = FindObjectOfType<PlayerController>();
        thePlayer.transform.position = transform.position;

        theCamera = FindObjectOfType<CameraController>();
        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
	}
	
}
