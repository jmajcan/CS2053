using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public Light myLight;
    public Light pLight;
    public Light sLight;
    public GameObject obstacle;
    public GameObject airCraft;
    private ArrayList obstacles;
    public Text timerText;
    public Text gameEndText;
    private int rounds = 1;
    private bool red = false; 

    // Use this for initialization
    void Start() {
        obstacles = new ArrayList();
        gameEndText.text = "";
        CreateObstacles(new Vector3(-18.21795f, -0.1095388f, -8.373059f), new Vector3(0.0f, 156.257f, 23.645f), "Cube");
        CreateObstacles(new Vector3(15.83022f, -0.1095388f, -12.15742f), new Vector3(0.0f, 38.331f, 92.814f), "Cube (1)");
        CreateObstacles(new Vector3(4.834189f, -0.1095388f, 19.38992f), new Vector3(0.0f, -74.79301f, -40.447f), "Cube (2)");
    }

    // Update is called once per frame
    void Update() {
        sLight.transform.LookAt(airCraft.transform);

        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Exit Game
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            // Pressing 'R' should restart the game, and can happen at anytime.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            if (!red) { RenderSettings.ambientSkyColor = Color.black; }
            else { RenderSettings.ambientSkyColor = Color.red; }
            red = !red;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            myLight.enabled = !myLight.enabled;
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            pLight.enabled = !pLight.enabled;
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            sLight.enabled = !sLight.enabled;
        }
    }

    private void Win() {
        gameEndText.text = "you win\n\nPress R to restart\nPress ESC to exit";
    }

    public void GameOver() {
        gameEndText.text = "Game Over! You pssed through "+rounds+" gates\n\nPress R to restart\nPress ESC to exit";
    }

    public void RemoveGap(GameObject obstacle, GameObject c) {
        rounds++;

        if (obstacle.name == "Obstacle (1)") {
            CreateObstacles(new Vector3(-18.21795f, -0.1095388f, -8.373059f), new Vector3(0.0f, 156.257f, 23.645f), "Cube");
        } else if (obstacle.name == "Obstacle (2)") {
            CreateObstacles(new Vector3(15.83022f, -0.1095388f, -12.15742f), new Vector3(0.0f, 38.331f, 92.814f), "Cube (1)");
        } else if (obstacle.name == "Obstacle") {
            CreateObstacles(new Vector3(4.834189f, -0.1095388f, 19.38992f), new Vector3(0.0f, -74.79301f, -40.447f), "Cube (2)");
        }
    }

    public GameObject CreateObstacles(Vector3 pos, Vector3 rot, string name) {
        GameObject gap_child = GameObject.CreatePrimitive(PrimitiveType.Cube);
        gap_child.transform.position = pos;
        gap_child.transform.Rotate(rot);
        gap_child.gameObject.tag = "Gap";
        gap_child.gameObject.name = name;
        MeshRenderer m = gap_child.GetComponent<MeshRenderer>();
        m.enabled = false;
        return gap_child;
    }
}