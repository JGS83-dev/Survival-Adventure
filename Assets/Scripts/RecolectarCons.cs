using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectarCons : MonoBehaviour {
    bool RangoR=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (RangoR == true && Input.GetKeyDown(KeyCode.R)){
            print("Recolectado");
            Destroy(gameObject);
        }
    }
    //-------------------------------------------------------------------------------------
    public void OnCollisionEnter2D(Collision2D coli)
    {
        RangoR = true;
    }
    //-------------------------------------------------------------------------------------
    private void OnCollisionExit2D(Collision2D coli2)
    {
        RangoR = false;
    }
    //-------------------------------------------------------------------------------------

}
