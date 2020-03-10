using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OrbitCameraController : MonoBehaviour
{
    public GameObject target;
    public float speed;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);
        transform.LookAt(target.transform);
    }
}
