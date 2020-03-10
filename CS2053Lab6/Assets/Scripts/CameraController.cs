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

}
