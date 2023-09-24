using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mensajes : MonoBehaviour {
    public string MSN;
    public float tiempo;
    public Text area;
    // Use this for initialization
    void Start () {
       
     
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void Carga(){
        MSN = "Bienvenido aventurero, estas por ingresar a un mundo que pondra a prueba tus conocimientos de supervivencia...";
        area.text = MSN;

        
    }
}
