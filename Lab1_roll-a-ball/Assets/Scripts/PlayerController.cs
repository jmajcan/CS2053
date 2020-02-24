using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public Text countText;
    public Text winText;
    public Text timerText;

    private int startTime = 30;
    private bool gameStart = false;
    private int timer;
    public float speed;
    private int count;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "Welcome to Jacob's Roll-A-Ball.\n\nPush 'S' to Start.";

        startTime = 10;
        timerText.text = "Timer: " + startTime.ToString();
    }

    private void Update() {
        if (gameStart == false && Input.GetKeyDown(KeyCode.S)) {
            gameStart = true;
            winText.text = "";
        }
        if (gameStart == true) {
            timer = startTime - (int)Time.timeSinceLevelLoad;
            ChangeTimeText();
        }
    }

    // Update is called once per frame
    private void FixedUpdate() {
        if (gameStart == true) {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            Vector3 movement = new Vector3(3.0f, 2.0f, moveVertical);
            rb.AddForce(movement);// * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //uncomment this in the next step
        //to notify the GameController that the game is over
        //gameController.GameOver();

        //this get rid of your PacMan
        //Destroy(gameObject);
    }

    private void SetCountText() {
        countText.text = "Count: " + count.ToString();
        if(count >= 12) {
            winText.text = "You Win";
        }
    }

    private void ChangeTimeText() {
        if (timer == 0)
        {
            winText.text = "you lose!";

            // Set Timer to 0
            timer = 0;
            timerText.text = "timer: " + timer.ToString();

            gameStart = false; // game ends
        }
        else
        {
            timerText.text = "timer: " + timer.ToString();
        }
    }
}
