using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PiedraGra : MonoBehaviour {
    public bool Rango = false;
    public Text Texto;
    public GameObject InvObj;
    //Variables de GameObjects a mandar parametros
    public Canvas AreTex;
    //-------------------------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {

    }
    //-------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        if (Rango == true && Input.GetKeyDown(KeyCode.R))
        {
            InvObj.SendMessage("RecibidoPie", 3);
            StartCoroutine(mos());
        }
    }
    //-------------------------------------------------------------------------------------
    public void OnCollisionEnter2D(Collision2D coli)
    {
        Rango = true;
    }
    //-------------------------------------------------------------------------------------
    private void OnCollisionExit2D(Collision2D coli2)
    {
        Rango = false;
    }
    //-------------------------------------------------------------------------------------
    public IEnumerator mos(){
        GetComponent<CircleCollider2D>().enabled = false;
        Rango = false;
        Texto.text = "Haz recolectado 3 piedras";
        AreTex.enabled = true;
        yield return new WaitForSeconds(0.5f);
        AreTex.enabled = false;
        Texto.text = " ";
        Destroy(gameObject);
    }
}
