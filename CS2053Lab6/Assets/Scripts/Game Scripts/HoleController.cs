using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleController : MonoBehaviour
{
    public GameController gameController;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9)) {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 3, gameObject.transform.localScale.y, gameObject.transform.localScale.z * 3);
        }

        if (Input.GetKey(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0)) {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x / 3, gameObject.transform.localScale.y, gameObject.transform.localScale.z / 3);
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (count == 7) {
            gameController.LoadMenu("win");
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Ball") {
            Destroy(collision.collider.gameObject);
            count++;
        }

        if (collision.collider.tag == "Player") {
            gameController.LoadMenu("lose");
        }
    }
}
