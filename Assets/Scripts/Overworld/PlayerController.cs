using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private GameManager gameManager;

    public float moveSpeed = 5;
    public string direction;
    public Vector2 lastMove;
    private bool isMoving;

    private Animator anim;
    private Rigidbody2D myRigidBody;


	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        isMoving = false;

        PlayerMovement();
        PauseMenu();

        // Set animation parameters
        anim.SetFloat("horizontalDirection", (Input.GetAxisRaw("Horizontal")));
        anim.SetFloat("verticalDirection", (Input.GetAxisRaw("Vertical")));
        anim.SetBool("isMoving", isMoving);

    }

    // Returns the direction that the character is facing in string format (up, right, down, left)
    public string Direction ()
    {
        if (Input.GetAxisRaw("Vertical") > 0.5)
        {
            return "up";
        }
        else if (Input.GetAxisRaw("Vertical") < -0.5)
        {
            return "down";
        }
        else if (Input.GetAxisRaw("Horizontal") > 0.5)
        {
            return "right";
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.5)
        {
            return "left";
        }
        else { return "standing"; }
    }

    // Governs overworld player movement
    void PlayerMovement()
    {
        if (!gameManager.Paused)
        {
            if (Input.GetButtonDown("Jump")) { moveSpeed = 15; }
            if (Input.GetButtonUp("Jump")) { moveSpeed = 5; }

            // Pressing left or right on input
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f)
            {

                myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);
                anim.SetFloat("lastHorizontal", Input.GetAxisRaw("Horizontal"));
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                anim.SetFloat("lastVertical", Input.GetAxisRaw("Vertical"));
                isMoving = true;
            }

            // Pressing up or down on input
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {

                myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);
                anim.SetFloat("lastHorizontal", Input.GetAxisRaw("Horizontal"));
                anim.SetFloat("lastVertical", Input.GetAxisRaw("Vertical"));
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                isMoving = true;
            }

            // Negligible or no input
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.5 && Mathf.Abs(Input.GetAxisRaw("Vertical")) < 0.5)
            {
                myRigidBody.velocity = new Vector2(0f, 0f);
            }
        }
        else { myRigidBody.velocity = new Vector2(0, 0); }
    }

    // Governs the start/end of the pause menu in the overworld
    void PauseMenu()
    {
        if (!gameManager.Paused)
        {
            if (Input.GetButtonDown("Cancel"))
            { gameManager.Paused = true; gameManager.PauseMenu = true; gameManager.TogglePauseMenu(); }
        }
        else
        {
            if (Input.GetButtonDown("Cancel"))
            { gameManager.Paused = false; gameManager.PauseMenu = false; gameManager.TogglePauseMenu(); }
        }
    }
}
