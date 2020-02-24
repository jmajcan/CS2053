using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AircraftController : MonoBehaviour
{
    float circleRadius;
    float circleSpeed;
    float circleAngle;
    float rotationAngle;
    float selfRotationSpeed;
    private bool canGoForward;
    Vector3 newPosition;
    Vector3 newDirection;
    Vector3 lastDirection;

    public Text timerText;
    public GameController gameController;
    private int startTime = 25;
    private int timer;
    private int countdown;
    private bool gameOver = false;
    private bool inGap = false;
    private int count = 0;
    public Component[] cubes;

    void Start() {
        canGoForward = false;
        circleRadius = 20;
        circleSpeed = 0.5f;
        circleAngle = 0;
        selfRotationSpeed = 100;
        UpdatePositions();
        UpdatePositions();
        countdown = startTime;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            // Pressing 'R' should restart the game, and can happen at anytime.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (!gameOver) {
            timer = countdown - (int)Time.time;
            ChangeTimeText();
        }

        // Pressing the “up” key, the Aircraft will go forward along the circular path.
        if (Input.GetKey("up") && !canGoForward && !gameOver){
            UpdatePositions();
        }
        // Pressing the “left” or “right” keys, the object will roll left or right.
        if (Input.GetKey("left") && !gameOver) {
            transform.Rotate(Vector3.forward, selfRotationSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey("right") && !gameOver) {
            transform.Rotate(Vector3.forward, -1 * selfRotationSpeed * Time.deltaTime, Space.Self);
        }
    }

    void OnTriggerEnter(Collider c) {
        if (c.gameObject.CompareTag("Gap")) {
            inGap = true;
            Destroy(c.gameObject);
        }
    }

    private void OnTriggerStay(Collider other) {
        canGoForward = true;
    }

    private void OnTriggerExit(Collider c) {
        canGoForward = false;
        if (inGap) {
            inGap = false;
            GameObject parentObject = c.gameObject.transform.parent.gameObject;
            gameController.RemoveGap(parentObject, gameObject);
            count++;
            if (count == 3) {
                // Resetting Timer
                startTime -= 2;
                countdown = startTime + (int)Time.time;
                // Resetting Count
                print(count + "\t" + timer);
                count = 0;
            }
        }
    }

    private void UpdatePositions() {
        circleAngle += circleSpeed * Time.deltaTime;
        circleAngle = (circleAngle + 360) % 360;
        float newPositionX = circleRadius * (float)Mathf.Cos(circleAngle);
        float newPositionZ = circleRadius * (float)Mathf.Sin(circleAngle);
        newPosition = new Vector3(newPositionX, transform.position.y, newPositionZ);
        newDirection = newPosition - transform.position;

        newDirection.Normalize();

        rotationAngle = -Vector3.Angle(lastDirection, newDirection);

        transform.position = newPosition;
        lastDirection = newDirection;
        transform.Rotate(Vector3.up, rotationAngle, Space.World);
    }

    private void ChangeTimeText() {
 
        if (timer <= 0) {
            gameController.GameOver();

            // Set Timer to 0
            timer = 0;
            timerText.text = "timer: " + timer.ToString();

            gameOver = true; // game ends
        }
        else {
            timerText.text = "timer: " + timer.ToString();
        }
    }
}