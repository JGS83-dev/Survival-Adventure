using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System;
public class GuardarObje : MonoBehaviour {
    public GameObject[] jarronesGuar;
    public GameObject[] madera;
    public GameObject[] piedra;

    public int i,k,l, tamaJar,tamaMad,tamaPie;
    private void Awake(){
        actua();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator actua(){
        yield return new WaitForSeconds(1);
        tamaJar = jarronesGuar.Length;
        tamaMad = madera.Length;
        tamaPie = piedra.Length;
        jarronesGuar = GameObject.FindGameObjectsWithTag("Jarron");
        madera = GameObject.FindGameObjectsWithTag("Madera");
        piedra = GameObject.FindGameObjectsWithTag("Piedra");
        print(jarronesGuar.Length);
        print(madera.Length);
        print(piedra.Length);
        guardarDatos();
    }
    void guardarDatos(){
        BinaryFormatter fb = new BinaryFormatter();//Ayudante para trabajar con archivos de guardado
        FileStream Expediente = File.Create(Application.persistentDataPath + "/Jarrones.d");//Crea el archivo de datos .d
        Datos Datos = new Datos();
        for (i = 0; i < tamaJar; i++){
            Datos.Jarrones[i] = jarronesGuar[i].transform.position;
            fb.Serialize(Expediente, Datos);
        }for (k = 0; k < tamaMad; k++){
            Datos.Madera[i] = madera[k].transform.position;
            fb.Serialize(Expediente, Datos);
        }
        for (l = 0; l < tamaPie; l++){
            Datos.Piedra[i] = piedra[k].transform.position;
            fb.Serialize(Expediente, Datos);
        }
        Expediente.Close();
    }
}
[Serializable()]
class Datos : System.Object{
    public Vector2[] Jarrones;
    public Vector2[] Madera;
    public Vector2[] Piedra;
}
