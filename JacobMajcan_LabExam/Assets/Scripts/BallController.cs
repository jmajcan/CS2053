using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public GameObject player;
    public Text gameWinText;
    // Start is called before the first frame update
    void Start()
    {
        gameWinText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)transform.position.y == -5) {
            Destroy(gameObject);
            gameWinText.text = "You LOSE!";
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.collider.name == "Goal") {
            Destroy(gameObject);
            gameWinText.text = "You Win!";
        }
    }
}
