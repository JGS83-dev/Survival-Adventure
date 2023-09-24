using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objetos : MonoBehaviour {
    //Variables
    //Objetos almacenados-Objetos total maximo
    public float MaderaAl;
    public float PiedraAl;
    int i = 0;
    int tama;
    const float MaderaTo= 25, PiedraTo = 15;
    //Manejo de datos con otros objetos del juego
    public GameObject[] Fogata;
    public Text MaderaTe;
    public Text PiedrTe;
    public Canvas InterfazActi;
    //-------------------------------------------------------------------------------------
    //Funciones
    private void Awake(){
        Fogata = GameObject.FindGameObjectsWithTag("FogataVa");
    }
    // Use this for initialization
    void Start () {
        MaderaTe.text = MaderaAl + " / " + MaderaTo;
        PiedrTe.text = PiedraAl + " / " + PiedraTo;
        tama = Fogata.Length;

    }
    //-------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update () {
       
	}
    //-------------------------------------------------------------------------------------
    //Funcion para recibir, almacenar y actualizar la cantidad de madera actual
    void RecibidoMa(float madera){
        MaderaAl += madera;
        for (i = 0; i < tama; i++) {
            Fogata[i].SendMessage("MadeAc", MaderaAl);
            print(i);
        }
        actua();
        print("Madera almacenada " + MaderaAl);
    }
    //-------------------------------------------------------------------------------------
    void RecibidoPie(float piedra){
        //Funcion para recibir, almacenar y actualizar la cantidad de piedra actual
        PiedraAl += piedra;
        for (i = 1; i < tama; i++){
            Fogata[i].SendMessage("PiedAc", PiedraAl);
        }
        actua();
    }
    //-------------------------------------------------------------------------------------
    void actua(){
        Fogata = GameObject.FindGameObjectsWithTag("FogataVa");
        tama = Fogata.Length;
        for (i = 0; i < tama; i++){
            Fogata[i].SendMessage("MadeAc", MaderaAl);
        }
        for (i = 0; i < tama; i++)
        {
            Fogata[i].SendMessage("PiedAc", PiedraAl);
        }
        Mathf.Clamp(MaderaAl, 0, MaderaTo);
        Mathf.Clamp(PiedraAl, 0, MaderaTo);
        MaderaTe.text = MaderaAl + " / " + MaderaTo;
        PiedrTe.text = PiedraAl + " / " + PiedraTo;
    }
    void UsarMad(int reduccion){
        MaderaAl -= reduccion;
        actua();
        for (i = 0; i < tama; i++){
            Fogata[i].SendMessage("MadeAc", MaderaAl);
            Fogata[i].SendMessage("PiedAc", PiedraAl);
            Fogata[i].SendMessage("actua");
        }
    }
}
