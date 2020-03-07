using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    float moveHorizontal;
    float moveVertical;
    private bool gameEnd;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        gameEnd = false;
    }

    // Update is called once per frame
    void Update() {
        // Game has ended
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Exit Game
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            // Restart Game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        Vector3 movement;
        if (Input.GetKey(KeyCode.UpArrow) && gameEnd == false && (transform.position.z <= 9)) {
            movement = new Vector3(0.0f, 0.0f, 1.0f);
            transform.position = transform.position + movement * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow) && gameEnd == false && (transform.position.z >= -8)) {
            movement = new Vector3(0.0f, 0.0f, -1.0f);
            transform.position = transform.position + movement * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && gameEnd == false && (transform.position.x >= -8)) {
            movement = new Vector3(-1.0f, 0.0f, 0.0f);
            transform.position = transform.position + movement * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) && gameEnd == false && (transform.position.x <= 8)) {
            movement = new Vector3(1.0f, 0.0f, 0.0f);
            transform.position = transform.position + movement * Time.deltaTime * speed;
        }
    }

    private void UpdateGameEnd() {
        gameEnd = true;
    }

}
