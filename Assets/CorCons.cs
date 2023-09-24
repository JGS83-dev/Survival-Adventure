using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorCons : MonoBehaviour
{
    public Sprite[] animacion;
    public int var;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
    }

    //Funcion para realizar las actualizaciones del sprite
    //Se reciben los parametros del script Info
    public void cambio(int pos)
    {
        var = pos;
        if (pos == 5)
        {
            this.GetComponent<Image>().sprite = animacion[0];
        }
        else
        {
            this.GetComponent<Image>().sprite = animacion[var];
        }
    }
    //-------------------------------------------------------------------------------------
}
