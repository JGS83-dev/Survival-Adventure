using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class Pause : MonoBehaviour {
    bool active;
    public Canvas canvas;
    public Canvas inventario;

    // Use this for initialization
    void Start () {
        canvas.enabled = false;
        inventario.enabled = false;
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P)){
            active = !active;
            canvas.enabled = active;
            Time.timeScale = (active) ? 0 : 1f;
        }if (Input.GetKeyDown(KeyCode.Space)){
            active = !active;
            inventario.enabled = active;
            Time.timeScale = (active) ? 0 : 1f;
        }
    }
}
