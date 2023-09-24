using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Script para poder desplazar la camara principal 
y tambien que no se salga de los bordes del mapa 
para no ver el espacio vacio*/
public class SegCamara : MonoBehaviour {
	public float smoothTime = 0.5f;
	Transform objetivo;
	float TLX,TLY,BRX,BRY; //Enviar parametros de cuanto mide el esenario
	Vector2 velocity; // necesario para el suavizado de cámara
	void Awake(){//Procedimiento propio de Unity (Se ejecuta antes del update)
		objetivo = GameObject.FindGameObjectWithTag("Player").transform;
	}
    void Start()
    {
        // Forzar la resolución cuadrada en pantalla completa
        Screen.SetResolution(800, 800, true);
    }
    // Update is called once per frame
    void Update () {
        // Forzar la resolución si no es cuadrada o pantalla completa
        // Permitir cerrar juego al presionar escape
        if (Input.GetKey("escape")) Application.Quit();
        
        //Seguimiento de la camara con suavizado 
        float posX = Mathf.Round(
			Mathf.SmoothDamp(transform.position.x,
				objetivo.position.x, ref velocity.x, smoothTime) * 100) / 100;
		float posY = Mathf.Round(
			Mathf.SmoothDamp(transform.position.y,
				objetivo.position.y, ref velocity.y, smoothTime) * 100) / 100;
		transform.position = new Vector3(
			Mathf.Clamp(posX,TLX,BRX),
			Mathf.Clamp(posY,BRY,TLY),
			transform.position.z
		);
	}
	public void setBound(GameObject mapa){
		Tiled2Unity.TiledMap config = mapa.GetComponent<Tiled2Unity.TiledMap>();//Recuperar script de los datos del mapa
		float tamcamara = Camera.main.orthographicSize;//Recuperar tamaño de la camara
		//Calculo de los limites para movimientos de camara
		TLX = mapa.transform.position.x + tamcamara;
		TLY = mapa.transform.position.y - tamcamara;
		BRX = mapa.transform.position.x + config.NumTilesWide - tamcamara;
		BRY = mapa.transform.position.y - config.NumTilesHigh + tamcamara;
		FastMove();
	}
	public void FastMove() {
		transform.position = new Vector3(
			objetivo.position.x,
			objetivo.position.y,
			transform.position.z
		);
	}
}
