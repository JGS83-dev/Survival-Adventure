using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Texto : MonoBehaviour{
    public string español;
    public string ingles;
    public string frances;
    public bool esBoton;
    public Toggle toggleEspañol;
    public Toggle toggleIngles;
    public Toggle toggleFrances;

    public IdiomaGlobal idiomaGlobal;

    // Use this for initialization
    void Start(){
        NotificationCenter.DefaultCenter().AddObserver(this, "CambiarIdioma_");
        CambiarIdioma_();
    }

    // Update is called once per frame
    void Awake()
    {
        idiomaGlobal = GameObject.Find("Scripts").GetComponent<IdiomaGlobal>();
    }


    public void CambiarIdioma_()
    {
        if (idiomaGlobal.RetornaIdioma() == "Español")
        {
            if (esBoton)
            {
                GetComponentInChildren<Text>().text = español;
            }
            else
            {
                GetComponent<Text>().text = español;
            }
        }
        if (idiomaGlobal.RetornaIdioma() == "Ingles")
        {
            if (esBoton)
            {
                GetComponentInChildren<Text>().text = ingles;
            }
            else
            {
                GetComponent<Text>().text = ingles;
            }
        }
        if (idiomaGlobal.RetornaIdioma() == "Frances")
        {
            if (esBoton)
            {
                GetComponentInChildren<Text>().text = frances;
            }
            else
            {
                GetComponent<Text>().text = frances;
            }
        }

    }
}
