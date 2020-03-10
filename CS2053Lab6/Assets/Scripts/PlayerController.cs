using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    Rigidbody rb;
    public AudioSource myAudio;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision collision) {
        if (myAudio != null && !myAudio.isPlaying &&
        myAudio.clip != null && myAudio.clip.loadState == AudioDataLoadState.Loaded
        ) {
            myAudio.Play();
        }
    }
}
