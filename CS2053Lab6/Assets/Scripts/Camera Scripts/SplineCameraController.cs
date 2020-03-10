using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineCameraController : MonoBehaviour {

    public GameObject target;

    CRSpline path = new CRSpline();
    int index = 1;
    float t = 0.0f;
    public float speed;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame

    void Update() {

        t += speed * Time.deltaTime;
        if (t >= 1.0f) {
            index++;
            t = t - 1.0f;
        }

        if (index + 2 < path.getSize()) {
            transform.position = path.compute(index, t);
        } else {
            index = 1;
        }
        transform.LookAt(target.transform);

    }
}

class CRSpline {
    Vector3[] controlPoints = {new Vector3(-10.0f, 3.0f, -6.0f),
        new Vector3(-8.0f, 4.0f, -2.0f),
        new Vector3(-6.0f, 5.0f, 2.0f),
        new Vector3(-4.0f, 6.0f, 6.0f),
        new Vector3(-6.0f, 5.0f, 8.0f),
        new Vector3(-8.0f, 4.0f, 2.0f),
        new Vector3(-10.0f, 4.0f, -2.0f)
    };

    public Vector3 compute(int start, float t) {
        Vector3 p0 = controlPoints[start - 1];
        Vector3 p1 = controlPoints[start];
        Vector3 p2 = controlPoints[start + 1];
        Vector3 p3 = controlPoints[start + 2];

        Vector3 position = 0.5f * ((2 * p1) + (-p0 + p2) * t + (2 * p0 - 5 * p1 + 4 * p2 - p3) * t * t + (-p0 + 3 * p1 - 3 * p2 + p3) * t * t * t);

        return position;
    }
    public int getSize() { return controlPoints.Length; }
}