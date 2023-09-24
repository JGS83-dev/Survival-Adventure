using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAni : MonoBehaviour {
    // Variable para guardar el nombre del estado animacion
    public string AnimState;
    // Animador para controlar la animación
    Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.Play(AnimState);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
