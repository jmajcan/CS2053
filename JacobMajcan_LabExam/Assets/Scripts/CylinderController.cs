using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour
{
    private Vector3 velocity;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(1f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        int change = Random.Range(0, 100);
        if (change == 0) {
            velocity = new Vector3(-velocity.x, 0f, -velocity.z);
        } else if (change == 1) {
            if (velocity.x != 0f) {
                velocity = new Vector3(0f, 0f, velocity.x);
            } else {
                velocity = new Vector3(velocity.z, 0f, 0f);
            }
        }

        if ((transform.position.x <= -8) && velocity.x < 0f) {
            velocity = new Vector3(1f, 0f, 0f);
        }
        if ((transform.position.x >= 8) && velocity.x > 0f) {
            velocity = new Vector3(-1f, 0f, 0f);
        }
        if ((transform.position.z <= -8) && velocity.z < 0f) {
            velocity = new Vector3(0f, 0f, 1f);
        }
        if ((transform.position.z >= 8) && velocity.z > 0f) {
            velocity = new Vector3(0f, 0f, -1f);
        }
        transform.position = transform.position + velocity * Time.deltaTime * speed;
    }
}
