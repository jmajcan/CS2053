using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    private int count;
    private GameObject gameControllerObject;
    private GameController gameController;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        count = 0;
        gameControllerObject = GameObject.Find("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    private void Update() {
        if((int)transform.position.y == -5) {
            Destroy(gameObject);
            count--;
            gameController.UpdateScore(-1);
        }
    }

    // Update is called once per frame
    private void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "cylinder") {
            gameController.UpdateScore(1);
        }
    }
}
