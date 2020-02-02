using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject ghost;
    public Text timerText;
    public Text gameEndText;
    private int timer = 0;
    private bool gameEnd = false;
    int i = 5;

    // Start is called before the first frame update
    private void Start() {
        SpawnGhost();
        gameEndText.text = ""; // Set End Game Text to nothing
        SetTimerText();
    }

    private void Update() {
        SetTimerText();

         // Game has ended
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Exit Game
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            // Restart Game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if ((int)Time.time == (i-1) && timer != 0 && gameEnd != true) {
            i += 5;
            SpawnGhost();
        }
    }

    private void SpawnGhost() {
        Instantiate(ghost, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    private void SetTimerText() {
        timerText.text = "Timer: " + timer.ToString();
 
        if (gameEnd == true) {
            timer += (int)Time.deltaTime; // pause time
        } else {
            timer = (int)Time.timeSinceLevelLoad + 1;
        }
    }

    public void GameOver() {
        timer = (int)Time.timeSinceLevelLoad;
        gameEnd = true;
        gameEndText.text = "GAME OVER\nPress ESC to exit\nPress R to restart.";
    }
}
