using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cofresObjetos : MonoBehaviour {
    public GameObject objeto;
    public Transform posicion;
    public GameObject[] drops;
    public float num;
    Animator anim;
    void Start(){
        anim = GetComponent<Animator>();
        
    }
    // Detectamos la colisión con una corrutina
   IEnumerator OnTriggerEnter2D(Collider2D col){
        // Si es un ataque
        if (col.tag == "Player"){
            // Reproducimos la animación de destrucción y esperamos
            anim.Play("cofreAbriendo");
            yield return new WaitForSeconds(1.2F);
            anim.Play("CofreAbierto");
            objeto.SendMessage("Drop");
            Destroy(GetComponent<cofresObjetos>());
        }
    }
    void Update(){
        
    }
    private void FixedUpdate(){
        
    }
    void Drop(){
        num = Random.Range(1, 3);
        if (num == 1) { Instantiate(drops[0], posicion.position, posicion.rotation); }
        if (num == 2) { Instantiate(drops[1], posicion.position, posicion.rotation); }
        else { }
    }
}
