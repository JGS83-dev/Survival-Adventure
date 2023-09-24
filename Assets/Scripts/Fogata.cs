using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fogata : MonoBehaviour {
    public GameObject fogataSt;
    public Transform fogataPo;
    public GameObject fogataMa;
    public GameObject fogataFin;
    public Canvas areaMen;
    public Text Mensaje;
    const int necesariosMad=7,necesariosPied=5;
    public int almacenadosMad,almacenadosPied,totMad,totPied;
    public bool LisFog;
    public GameObject InventarioObj;
	// Use this for initialization
	void Start (){
        totMad = necesariosMad - almacenadosMad;
        totPied = necesariosPied - almacenadosPied;
    }
	// Update is called once per frame
	void Update (){
	
	}
    public void OnTriggerEnter2D(Collider2D coli){
        if(coli.tag == "Player"){
            if (LisFog == false){
                StartCoroutine(informacion());
            }else if(LisFog == true){
                StartCoroutine(informacion2());
            }
        }
    }
    public IEnumerator informacion(){
        Mensaje.text = "Recolecta madera y piedras para hacer una fogata\n El frio es tu mayor enemigo.";
        areaMen.enabled = true;
        yield return new WaitForSeconds(1);
        if (totMad >= 0){
            Mensaje.text += "\nTe hacen falta " + totMad + " de madera.";
            yield return new WaitForSeconds(1);
        }if (totPied >= 0){
            Mensaje.text += "\nTe hacen falta " + totPied + " de piedra.";
            yield return new WaitForSeconds(1);
        }
        Mensaje.text = "";
        areaMen.enabled = false;
    }
    public IEnumerator informacion2(){
        areaMen.enabled = true;
        Mensaje.text = "Haciendo fogata";
        InventarioObj.SendMessage("UsarMad", necesariosMad);
        Instantiate(fogataMa, fogataPo);
        yield return new WaitForSeconds(0.5f);
        Instantiate(fogataFin, fogataPo.position,fogataPo.rotation);
        Mensaje.text = "";
        areaMen.enabled = false;
        InventarioObj.SendMessage("actua");
        Destroy(fogataSt);
    }
    void MadeAc(int made){
        almacenadosMad = made;
        actua();
    }
    void PiedAc(int pied){
        almacenadosPied = pied;
        actua();
    }
    void actua(){
        totMad = necesariosMad - almacenadosMad;
        totPied = necesariosPied - almacenadosPied;
        if(totMad<=0 && totPied <= 0){
            LisFog = true;
        }
        else{
            LisFog = false;
        }
    }
}
