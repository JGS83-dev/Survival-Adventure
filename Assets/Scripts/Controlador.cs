using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class Controlador : MonoBehaviour {

    public bool nuevapartida;
    

    void Awake()
    {
        nuevapartida = cargamos(nuevapartida);
    }

    public void Guarda(){
        nuevapartida = true;
        print("Nueva partida");
        print(nuevapartida);
        guardamos(nuevapartida);
        SceneManager.LoadScene("Carga");
    }
    public void Carga()
    {
        nuevapartida = false;
        print("Cargando partida");
        print(nuevapartida);
        guardamos(nuevapartida);
        SceneManager.LoadScene("Carga");
    }

    public void Salir(){
        Debug.Log("Esta saliendo del juego");
        Application.Quit(); 
    }
    public void guardamos(bool inicio)
    {
        BinaryFormatter bf = new BinaryFormatter();//Ayudante para trabajar con archivos de guardado
        FileStream Expediente = File.Create(Application.persistentDataPath + "/Guardado.d");//Crea el archivo de datos .d
        Botones bot = new Botones();
        bot.Nueva = inicio;
        bf.Serialize(Expediente, bot);
        Expediente.Close();
    }
    public bool cargamos(bool inicio)
    {
        if (File.Exists(Application.persistentDataPath + "/Guardado.d"))
        {//Verificamos
            BinaryFormatter fb = new BinaryFormatter();
            FileStream Expediente = File.OpenRead(Application.persistentDataPath + "/Guardado.d");//Crea el archivo de datos .d
            Botones bot = new Botones();
            bot = fb.Deserialize(Expediente) as Botones;//Nuestros datos se convertiran en los datos del archivo
            //Cargamos los datos
            inicio = bot.Nueva;
            print("Cargado");//Comprobar
        }
        else
        {
            print("No habia ningun archivo");
        }
        return inicio;
    }
    public void cambia(){
        SceneManager.LoadScene("Carga 1");
    }
}

[Serializable()]
class Botones : System.Object
{
    public bool Nueva;
}