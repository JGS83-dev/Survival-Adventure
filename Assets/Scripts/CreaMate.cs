using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaMate : MonoBehaviour {
    public Transform SpawnArea;
    public GameObject Objeto_Crear;
    public float tiempo;
    public bool crear,Rango;
	// Use this for initialization
	void Start () {
        crear = true;
        Creacion();
	}
	
	// Update is called once per frame
	void Update () {
        if (Rango == true && Input.GetKeyDown(KeyCode.R)){
            crear = true;
            StartCoroutine(Creacion());
        }
    }
     void OnTriggerEnter2D(Collider2D coli){
        if (coli.tag == "Player"){
            Rango = true;
        }
    }
     void OnTriggerExit2D(Collider2D coli){
        if (coli.tag == "Player"){
            Rango = false;
        }
    }
    IEnumerator Creacion(){
        if (crear == true){ 
        yield return new WaitForSeconds(tiempo);
        Instantiate(Objeto_Crear, SpawnArea.position,SpawnArea.rotation);
            crear = false;
        }
    }
}
