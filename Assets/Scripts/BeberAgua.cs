using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeberAgua : MonoBehaviour {
    public bool RangoAg;
    public GameObject estadis;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (RangoAg == true && Input.GetKeyDown(KeyCode.R)){
            estadis.SendMessage("SumarAgua", 10);
            print("Agua bebida");
        }
    }
    //-------------------------------------------------------------------------------------
    public void OnCollisionEnter2D(Collision2D coli)
    {
        RangoAg = true;
    }
    //-------------------------------------------------------------------------------------
    private void OnCollisionExit2D(Collision2D coli2)
    {
        RangoAg = false;
    }
    //-------------------------------------------------------------------------------------
}
