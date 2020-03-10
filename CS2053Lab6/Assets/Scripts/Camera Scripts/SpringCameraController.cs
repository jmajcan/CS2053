using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringCameraController : MonoBehaviour
{
    public GameObject target;

    float springConstant = 9.0f;
    float dampConstant;

    Vector3 offset;
    Vector3 actualPosition;
    Vector3 velocity;

    // Use this for initialization
    void Start() {
        dampConstant = 2.0f * (float)Math.Sqrt(springConstant);
        offset = transform.position - target.transform.position;
        actualPosition = transform.position;
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update() {
        Vector3 idealPosition = target.transform.position + offset;
        Vector3 displacement = actualPosition - idealPosition;
        Vector3 springAccel = (-springConstant * displacement) - (dampConstant * velocity);
        velocity += springAccel * Time.deltaTime;
        actualPosition += velocity * Time.deltaTime;
        transform.position = actualPosition;
    }
}
