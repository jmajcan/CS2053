using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Camera staticCamera;
    public Camera followCamera;
    public Camera springCamera;
    public Camera orbitCamera;
    public Camera firstPersonCamera;
    public Camera splineCamera;

    public string choice = "static";

    // Use this for initialization
    void Start() {
        staticCamera.enabled = false;
        followCamera.enabled = false;
        springCamera.enabled = false;
        orbitCamera.enabled = false;
        firstPersonCamera.enabled = false;
        splineCamera.enabled = false;

        if (choice == "static") { staticCamera.enabled = true; }
        if (choice == "follow") { followCamera.enabled = true; }
        if (choice == "spring") { springCamera.enabled = true; }
        if (choice == "orbit") { orbitCamera.enabled = true; }
        if (choice == "fp") { firstPersonCamera.enabled = true; }
        if (choice == "spline") { splineCamera.enabled = true; }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) {
            staticCamera.enabled = true;
            followCamera.enabled = false;
            springCamera.enabled = false;
            orbitCamera.enabled = false;
            firstPersonCamera.enabled = false;
            splineCamera.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) {
            staticCamera.enabled = false;
            followCamera.enabled = true;
            springCamera.enabled = false;
            orbitCamera.enabled = false;
            firstPersonCamera.enabled = false;
            splineCamera.enabled = false;
        }
        if (Input.GetKey(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) {
            staticCamera.enabled = false;
            followCamera.enabled = false;
            springCamera.enabled = true;
            orbitCamera.enabled = false;
            firstPersonCamera.enabled = false;
            splineCamera.enabled = false;
        }
        if (Input.GetKey(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) {
            staticCamera.enabled = false;
            followCamera.enabled = false;
            springCamera.enabled = false;
            orbitCamera.enabled = true;
            firstPersonCamera.enabled = false;
            splineCamera.enabled = false;
        }
        if (Input.GetKey(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) {
            staticCamera.enabled = false;
            followCamera.enabled = false;
            springCamera.enabled = false;
            orbitCamera.enabled = false;
            firstPersonCamera.enabled = true;
            splineCamera.enabled = false;
        }
        if (Input.GetKey(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6)) {
            staticCamera.enabled = false;
            followCamera.enabled = false;
            springCamera.enabled = true;
            orbitCamera.enabled = false;
            firstPersonCamera.enabled = false;
            splineCamera.enabled = false;
        }
    }
}
