using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneVida : MonoBehaviour {
    public bool val=false;
    public GUIStyle EstiloCaja;
    public Transform muePos;
    public GameObject objeto;
    public GameObject drop;
    public float vidaMax;
    public float hp;
    public int aleatorio;
    public int dano;
    // Use this for initialization
    void Start() {
        hp = vidaMax;
    }

    // Update is called once per frame
    void Update() {

    }
    /*private void OnTriggerEnter2D(Collider2D coli){
        if (coli.tag == "Ataque") ;
        objeto.SendMessage("atacado");
        
    }*/
    public void atacado() {
        val = true;
        if ((hp -= dano) <= 0){
            Destroy(gameObject);
            Instantiate(drop, muePos.position, muePos.rotation);
        }
    }
    void OnGUI(){
        if (val==true){ 
        EstiloCaja.fontSize = 30;
        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Box(
            new Rect(
                pos.x - 20,
                Screen.height - pos.y + 40,60,30),hp + "/" + vidaMax);
        }
    }
}
