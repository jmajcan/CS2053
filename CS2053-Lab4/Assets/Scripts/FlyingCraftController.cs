using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCraftController : MonoBehaviour {
    public GameController gameController;
    private bool inGap;
    private bool gameOn;

    private float rotationAngleDegree;
    private float rotationSpeedDegree;
    int rotationDirection;

    private Vector3 motionVelocity;
    private float motionSpeedXZ;
    private int motionDirectionXZ;

    private float motionSpeedY;
    private int motionDirectionY;

    // Start is called before the first frame update
    void Start() {
        inGap = false;
        gameOn = true;

        rotationAngleDegree = 0;
        rotationSpeedDegree = 25;
        rotationDirection = 0;

        motionVelocity = Vector3.zero;
        motionSpeedXZ = 15;
        motionDirectionXZ = 0;

        motionSpeedY = 5.0f;
        motionDirectionY = 0;
    }

    // Update is called once per frame
    void Update() {
        // No forward or backwards controls are needed.
        // Update the spaceship so that it always flies forwards at a constant speed.
        motionDirectionXZ = -1;
        Move();
        if (gameOn) {
            if (Input.GetKey("space")) {
                motionDirectionY = 0;
                Move();
            }

            if (Input.GetKey("right")) {
                rotationDirection = 1;
                Rotate();
            }

            if (Input.GetKey("left")) {
                rotationDirection = -1;
                Rotate();
            }

            // Update the ship's controller, so that the up and down arrows allow you fly up higher or lower.
            if (Input.GetKey("up")) {
                motionDirectionY = 1;
                Move();
            }

            if (Input.GetKey("down")) {
                motionDirectionY = -1;
                Move();
            }

            if (Input.GetKey("u")) {
                motionDirectionY = 1;
                Move();
            }

            if (Input.GetKey("d")) {
                motionDirectionY = -1;
                Move();
            }
        } else {
            motionSpeedXZ = 0;
            rotationSpeedDegree = 0;
            motionSpeedY = 0.0f;
        }
    }

    private void Rotate() {
        float rotationVelocityDegree = rotationSpeedDegree * rotationDirection;
        rotationAngleDegree += rotationVelocityDegree * Time.deltaTime;

        //make sure that rotationAngleDegree within 0-360
        rotationAngleDegree = (rotationAngleDegree + 360) % 360;
        transform.Rotate(Vector3.up, rotationVelocityDegree * Time.deltaTime); //Vector.up is Y-Axis
    }

    private void Move() {
        //convert degree to radian
        double rotationAngleRadian = ((float)rotationAngleDegree / 360.0) * (Math.PI * 2.0);
        float motionX = (float)Math.Sin(rotationAngleRadian) * motionDirectionXZ;
        float motionZ = (float)Math.Cos(rotationAngleRadian) * motionDirectionXZ;

        //Add the following
        float motionY = motionDirectionY;
        motionVelocity = new Vector3(motionX, motionY, motionZ);

        //nomoralized vector to represent the directions of motionVelocity
        motionVelocity.Normalize();
        motionVelocity = new Vector3(motionVelocity.x * motionSpeedXZ, motionVelocity.y * motionSpeedY, motionVelocity.z * motionSpeedXZ);
        transform.position += motionVelocity * Time.deltaTime;

        rotationDirection = 0;
        motionDirectionXZ = 0;
    }

    void OnTriggerEnter(Collider c) {
        if (c.gameObject.tag == "Obstacle") {
            gameOn = false;
            gameController.GameOver();
        }
        else if (c.gameObject.tag == "Ground") {
            gameOn = false;
            gameController.GameOver();
        }
        if (c.gameObject.tag == "Gap") {
            inGap = true;
        }
    }

    void OnTriggerExit(Collider c) {
        if (inGap) {
            inGap = false;
            GameObject parentObject = c.gameObject.transform.parent.gameObject;
            gameController.Score(parentObject, gameObject);
        }
    }

    public void Stop() {
        gameOn = false;
    }
}
