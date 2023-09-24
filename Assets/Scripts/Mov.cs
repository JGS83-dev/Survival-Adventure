using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public class Mov : MonoBehaviour {
    //Variables
    public GameObject fogata;
    public bool PerCorrer;
    public bool bandera;
    public GameObject conejo;
    public bool AniAtaqueAct=false;
    public int X, Y;
    public Transform spawnPos;
    public GameObject spawnObj;
    public Transform spawnPos2;
    public GameObject spawnObj2;
    public GameObject padreColi;
    public GameObject mapainicial;
    public GameObject Player;
    public GameObject audio1;
    public GameObject audio2;
    public GameObject energiaObj;
    public float restar;
	public float speed= 2f;//Velocidad de movimiento
	public float au=1.5f;//Aumento de velociadad
	//Variables usadas para detectar animaciones, colisiones y movimiento
    //-------------------------------------------------------------------------------------
	Animator anim;
	Rigidbody2D cuerpo;
    public Vector2 mov;
    public Vector2 pos;
    CircleCollider2D attackCollider;

    //-------------------------------------------------------------------------------------
    void Awake(){
        energiaObj.SetActive(false);
        audio1.GetComponent<AudioSource>().Play();
		Assert.IsNotNull (mapainicial);
	}
    //-------------------------------------------------------------------------------------
    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator> ();
		cuerpo = GetComponent<Rigidbody2D> ();
		Camera.main.GetComponent<SegCamara>().setBound (mapainicial);
        // Recuperamos el collider de ataque del primer hijo
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        // Lo desactivamos desde el principio, luego
        attackCollider.enabled = false;
        bandera = false;
    }
    //-------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update (){
		mov = new Vector2 (
			Input.GetAxisRaw ("Horizontal"),
			Input.GetAxisRaw ("Vertical"));
		if(mov !=Vector2.zero){
			anim.SetFloat ("MovX", mov.x);
			anim.SetFloat ("MovY", mov.y);
			anim.SetBool ("Caminando", true);
		}else{anim.SetBool ("Caminando", false);
		}
        // Buscamos el estado actual mirando la información del animador
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool attacking = stateInfo.IsName("Ataque");

        // Detectamos el ataque, tiene prioridad por lo que va abajo del todo
        if (Input.GetKey(KeyCode.X) && !attacking){
            anim.SetTrigger("atacando");
        }
        // Vamos actualizando la posición de la colisión de ataque
        if (mov != Vector2.zero) attackCollider.offset = new Vector2 (mov.x / 3, mov.y / 3);

        // Activamos el collider a la mitad de la animación de ataque
        if (attacking){
            AniAtaqueAct = true;
            float playbackTime = stateInfo.normalizedTime;
            if (playbackTime > 0.33 && playbackTime < 0.66) attackCollider.enabled = true;
            else attackCollider.enabled = false;
        }
    }
    //-------------------------------------------------------------------------------------
    public void cancelarAni(bool var){
        anim.SetBool("Caminando", var);
    }
    //-------------------------------------------------------------------------------------
    void FixedUpdate(){
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftControl) && PerCorrer == true){
            if(mov != Vector2.zero){
            Player.SendMessage("corriendo",true);
            energiaObj.SetActive(true);
			cuerpo.MovePosition(cuerpo.position + mov * (speed * au) * Time.deltaTime);
            }
        }else{
            energiaObj.SetActive(false);
            Player.SendMessage("corriendo", false);
            cuerpo.MovePosition(cuerpo.position + mov * speed * Time.deltaTime);
		}
	}
    //-------------------------------------------------------------------------------------
    public void OnTriggerEnter2D(Collider2D coli){
        /*if(coli.tag == "FogataVa"){
            fogata.SendMessage("informacion");
                }*/
        if (coli.tag == "Dano"){
           pos = new Vector2(2,1);
            cuerpo.MovePosition(cuerpo.position + pos * (speed * au) * Time.deltaTime);
            Player.SendMessage("RestarVida", restar);
        }
        if (coli.tag == "Recolectar"){
            Destroy(coli.gameObject);
            Player.SendMessage("SumarVida", 2.5);
        }/*if (coli.tag == "Manzana"){
            Destroy(coli.gameObject);
            Player.SendMessage("SumarComida", 5);
        }if (coli.tag == "Banana"){
            Destroy(coli.gameObject);
            Player.SendMessage("SumarComida", 10);
        }if (coli.tag == "Sandia"){
            Destroy(coli.gameObject);
            Player.SendMessage("SumarComida", 25);
        }*/if (coli.tag == "Activador"){
            Destroy(coli.gameObject);
            Instantiate(spawnObj, spawnPos.position, spawnPos.rotation);
        }if (coli.tag == "Activador2"){
            Destroy(padreColi.gameObject);
            Instantiate(spawnObj2, spawnPos2.position, spawnPos2.rotation);           
        }if (coli.tag == "musicaC"){
            if (audio2.GetComponent<AudioSource>().isPlaying){
                audio1.GetComponent<AudioSource>().Stop();
            }else{
                audio2.GetComponent<AudioSource>().Play ();
                audio1.GetComponent<AudioSource>().Stop();
            }
        }if (coli.tag == "musicaB"){
            if (audio1.GetComponent<AudioSource>().isPlaying){
                audio2.GetComponent<AudioSource>().Stop();
            }else{
                audio1.GetComponent<AudioSource>().Play();
                audio2.GetComponent<AudioSource>().Stop();
            }    
        }if (AniAtaqueAct && coli.tag == "Animal"){
            coli.SendMessage("atacado");
        }
    }
    //-------------------------------------------------------------------------------------
    public void rectificar(bool energia){
        PerCorrer = energia;
    }
    //-------------------------------------------------------------------------------------
}
