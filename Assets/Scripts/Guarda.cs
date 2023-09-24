using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Guarda : MonoBehaviour {

    public GameObject Player;
    public GameObject Camara;
    //Autocargado al emperzar
    public bool CargarAlInicio;
    public Controlador control;
    // Use this for initialization
    void Start () {
        if (control.nuevapartida == true)
        {
            Borrar();
            print("Nueva partida");
        }
        else
        {
            Cargar();
            print("Partida Cargada");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Guardar();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Cargar();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Borrar();
        }
    }
    //Sistema de guardado
    public void Guardar()
    {
        BinaryFormatter fb = new BinaryFormatter();//Ayudante para trabajar con archivos de guardado
        FileStream Expediente = File.Create(Application.persistentDataPath + "/Datos.d");//Crea el archivo de datos .d
        DatosDeJuego Datos = new DatosDeJuego();
        //Estos son los datos de juego que estan dentro de datos
        //Jugador
        GameObject.FindGameObjectWithTag("Player");
        Datos.NumeroEntero = Player.transform.position.x;
        Datos.NumeroDecimal = Player.transform.position.y;
        Datos.Text = Player.transform.position.z;
        //Camara
        Datos.posicioncamara = new float[3];
        GameObject.FindGameObjectWithTag("MainCamera");
        Datos.posicioncamara[0] = Camara.transform.position.x;
        Datos.posicioncamara[1] = Camara.transform.position.y;
        //El ayudante serializara los archivos
        fb.Serialize(Expediente, Datos);
        Expediente.Close();
        print("Guardado");//Comprobar
    }

    public void Cargar()
    {
        if (File.Exists(Application.persistentDataPath + "/Datos.d")) {//Verificamos
            BinaryFormatter fb = new BinaryFormatter();
            FileStream Expediente = File.OpenRead(Application.persistentDataPath + "/Datos.d");//Crea el archivo de datos .d
            DatosDeJuego Datos = new DatosDeJuego();
            Datos = fb.Deserialize(Expediente) as DatosDeJuego;//Nuestros datos se convertiran en los datos del archivo
            //Cargamos los datos
            Player.transform.position = new Vector3(Datos.NumeroEntero, Datos.NumeroDecimal, Datos.Text);
            Camara.transform.position = new Vector3(Datos.posicioncamara[0], Datos.posicioncamara[1],-10);
            print("Cargado");//Comprobar
        }
        else
        {
            print("No habia ningun archivo");
        }
    }
    public void Borrar()
    {
        if (File.Exists(Application.persistentDataPath + "/Datos.d"))
        {
            File.Delete(Application.persistentDataPath + "/Datos.d");
            //Nuestos datos se reiniciaran
                
            print("Borrado");
        }
        else
        {
            print("No habia ningun archivo");
        }
    }
}

[Serializable()]
class DatosDeJuego : System.Object{
    public float NumeroEntero;
    public float NumeroDecimal;
    public float Text;
    public float[] posicioncamara;
}
