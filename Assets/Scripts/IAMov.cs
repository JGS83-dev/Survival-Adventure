using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAMov : MonoBehaviour {
    //Variables
    float X, Y;
    float ident;
    float speed = 2f;
    Rigidbody2D cuerpo;
    Vector2 posi;
    public GameObject IA;
    Animator anim;
    //-------------------------------------------------------------------------------------
    // Use this for initialization
    void Start() {
        cuerpo = GetComponent<Rigidbody2D>();
        movimiento();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update(){
        anim.SetFloat("movX", posi.x);
        anim.SetFloat("movY", posi.y);
        anim.SetBool("walking", true);
    }
    void FixedUpdate() {
        cuerpo.MovePosition(cuerpo.position + posi * speed * Time.deltaTime);
    }
    //-------------------------------------------------------------------------------------
    public void movimiento() {
        ident = Random.Range(1, 5);
        /*
     1 --> Movimiento en X positivo
     2 --> Movimiento en X negativo
     3 --> Movimiento en Y positivo
     4 --> Movimiento en Y negativo
         */
        if (ident == 1){
            X = Random.Range(0f, 0.5f);
            Y = 0;
            posi = new Vector2(X, Y);
            IA.SendMessage("FixedUpdate");
        }
        if (ident == 2){
            X = Random.Range(-0.5f, 0f);
            Y = 0;
            posi = new Vector2(X,Y);
            IA.SendMessage("FixedUpdate");
        }
        if (ident == 3){
            X = 0;
            Y = Random.Range(0f, 0.5f);
            posi = new Vector2(X,Y);
            IA.SendMessage("FixedUpdate");
        }
        if (ident == 4){
            X = 0;
            Y = Random.Range(-0.5f, 0f);
            posi = new Vector2(X,Y);
            IA.SendMessage("FixedUpdate");
        }
        Invoke("movimiento",1f);
    }
    //-------------------------------------------------------------------------------------
}
