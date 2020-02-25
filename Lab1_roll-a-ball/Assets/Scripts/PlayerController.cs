using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    AudioSource pickupSound;
    Vector3 movement;

    public Text countText;
    public Text winText;
    public Text timerText;

    private bool gameStart = false;
    private bool gameEnd = false;

    private int startTime;
    private int timer;
    private int count;

    public float speed;
    float moveHorizontal;
    float moveVertical;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        pickupSound = GetComponent<AudioSource>();

        count = 0;
        SetCountText();
        winText.text = "Welcome to Jacob's Roll-A-Ball.\n\nPush 'S' to Start.\nPress ESC to exit game.";

        startTime = 30;
        timerText.text = "Timer: " + startTime.ToString();
    }

    private void Update() {

        if (gameStart == false && Input.GetKeyDown(KeyCode.S)) { // Check if the user wants to start the game
            gameStart = true;
            gameEnd = false;
            winText.text = "";
        } else if (Input.GetKeyDown(KeyCode.Escape)) { // Check if user is exiting the game
            Application.Quit();
        }
        if (gameStart == true) {
            // Start counting down to zero
            timer = startTime - (int)Time.timeSinceLevelLoad;
            ChangeTimeText();
        }
        if (gameEnd == true) {
            if (Input.GetKeyDown(KeyCode.R)) {
                RestartGame();
            } else if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate() {
        if (gameStart == true && gameEnd == false) {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");

            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pick Up")) {
            pickupSound.Play();
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText() {
        countText.text = "Count: " + count.ToString();
        if (count >= 12) {
            winText.text = "YOU WIN!!\n\nPress R to restart the game.\nPress ESC to exit game";
            gameEnd = true;
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");

            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void ChangeTimeText() {
        if (timer == 0) {
            winText.text = "You Lose!\n\nPress R to restart the game.\nPress ESC to exit game";

            // Set Timer to 0
            timer = 0;
            timerText.text = "timer: " + timer.ToString();

            // game ends
            gameStart = false;
            gameEnd = true;
        } else {
            timerText.text = "timer: " + timer.ToString();
        }
    }

    private void RestartGame() {
        if (Input.GetKeyDown(KeyCode.R)) {
            // Reload the current scene (the actual game)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
