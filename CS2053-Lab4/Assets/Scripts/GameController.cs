using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
    public GameObject obstacle;
    private ArrayList obstacles;
    public Text scoreText;
    public Text gameOverText;

    // Use this for initialization
    void Start() {
        obstacles = new ArrayList();
        CreateObstacles();
        gameOverText.text = "";
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = "Obstacles remaining: " + obstacles.Count;

        // Game has ended
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Exit Game
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            // Pressing 'R' should restart the game, and can happen at anytime.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Win() {
        gameOverText.text = "you win\n\nPress R to restart\nPress ESC to exit";
    }

    public void GameOver() {
        gameOverText.text = "Game Over!\n\nPress R to restart\nPress ESC to exit";
    }

    public void Score(GameObject obstacle, GameObject sender) {
        if (obstacles.Contains(obstacle)) {
            obstacles.Remove(obstacle);
        }

        if (obstacles.Count == 0) {
            Win();
            sender.gameObject.SendMessage("Stop");
        }
    }

    public void CreateObstacles() {
        // Adding Original Obstacle
        obstacles.Add(Instantiate(obstacle, new Vector3(-132, 48, 146), Quaternion.AngleAxis(45f, Vector3.up)));
        obstacles.Add( Instantiate(obstacle, new Vector3(142, 33, 33), Quaternion.identity) );
        obstacles.Add( Instantiate(obstacle, new Vector3(-33, 68, -86), Quaternion.AngleAxis(-35f, Vector3.up)) );
    }
}