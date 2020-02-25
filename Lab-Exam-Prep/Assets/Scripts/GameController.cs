using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Transform prefab;
    public GameObject player;
    public Text score;
    private int currentScore;

    // Start is called before the first frame update
    void Start() {
        Instantiate(player.transform, new Vector3(Random.Range(-4.0f, 4.0f), 0.5f, Random.Range(-4.0f, 4.0f)), Quaternion.identity);
        for (int i = 0; i < 7; i++) {
            Instantiate(prefab, new Vector3(Random.Range(-4.0f, 4.0f), 0, Random.Range(-4.0f, 4.0f)), Quaternion.identity);
        }
        currentScore = 0;
        score.text = "Score: " + currentScore;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(player.transform, new Vector3(Random.Range(-4.0f, 4.0f), 0.5f, Random.Range(-4.0f, 4.0f)), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Exit Game
            Application.Quit();
        }
    }

    public void UpdateScore(int count) {
        if (count > 0) {
            currentScore++;
        } else if (count < 0) {
            currentScore--;
        }
        score.text = "Score: " + currentScore;
    }
}
