using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
public class Tuto : MonoBehaviour{
    //Variables
    public GameObject musica1,musica2;
    public Text estado;
    public float faltantes, totales;
    public GameObject estadisticas, cuadro;
    public bool active;
    public Canvas canvas2;
    public int cont=1;
    // Use this for initialization
    public void Awake(){
        tutorial();
    }
    void Start(){

    }
    public void tutorial(){
        musica1.GetComponent<AudioSource>().Stop();
        musica2.GetComponent<AudioSource>().Stop();
        estadisticas.SetActive(false);
        cuadro.SetActive(true);
        estado.text = "Bienvenido aventurero";
        estado.text = estado.text + "\nUsa las teclas WASD o flechas para moverte";
        estado.text = estado.text + "\nUsa la tecla 'X' para usar la espada";
        estado.text = estado.text + "\nPresiona la tecla Z para continuar.....";
        canvas2.enabled = true;
        Time.timeScale = 0f;
        cont++;
    }
    /*public IEnumerator tutorial2(){
        yield return new WaitForSeconds(2);
        estado.text = "Para iniciar con esta aventura debes conocer algunas cosas";
        estado.text = estado.text + "\nDebes tener cuidado de no quedarte sin comida";
        estado.text = estado.text + "\nVigila tambien tu nivel de agua es muy importante";
        estado.text = estado.text + "\nMantente hidratado todo el tiempo";
        estado.text = estado.text + "\nPresiona la tecla Z para continuar";
        canvas2.enabled = true;
        Time.timeScale = 0f;
        cont++;
    }*/
    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Z)){
            Time.timeScale = 1f;
            estadisticas.SetActive(true);
            cuadro.SetActive(false);
            musica1.GetComponent<AudioSource>().Play();
            //tutorial2();
        }
    }
}
