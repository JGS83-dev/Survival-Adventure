using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
public class Info : MonoBehaviour {
    //Interfaz grafica de las estadisticas
    public GameObject EstadoVida;
    public GameObject EstadoComida;
    public GameObject EstadoEnergia;
    public GameObject EstadoAgua;
    public GameObject player;
    public GameObject vidaStat;
    public GameObject aguaStat;
    public GameObject energiaStat;
    public GameObject comidaStat;
    //-------------------------------------------------------------------------------------
    //Texto mostrado
    public Text VidaActual;
    public Text ComidaActual;
    public Text EnergiaActual;
    public Text AguaActual;
    //-------------------------------------------------------------------------------------
    //Variables de estadisticas y cambios
    public bool estado;
    public float Vida;
    public float VidaDis;
    public float Comida;
    public float ComidaDis;
    public float ComidaDis2;
    public float Energia;
    public float EnergiaDis;
    public float Agua;
    public float AguaADis;
    public float AguaDis2;
    public float velocidad;
    //-------------------------------------------------------------------------------------
    //Aumento de datos
    public float VidaAu;
    public float EnergiaAu;
    public float AguaAu;
    public float ComidaAu;
    //-------------------------------------------------------------------------------------
    public float ParaComAuVida;//Recuperacion de vida
    //-------------------------------------------------------------------------------------
    public GameObject final;
    public GameObject jugador;
    public GameObject energiaObj;
    //-------------------------------------------------------------------------------------
    //Funciones para cambios de estadisticas
    public void actua(){
        if (Comida > ParaComAuVida && Vida<100 ){
            SumarVida(VidaAu);
            RestarComida(ComidaDis2);
        }if(Comida>0){
            RestarComida(ComidaDis);
        }if (Comida < ParaComAuVida && Comida!=0){
            RestarComida(ComidaDis);
        }if (Comida == 0){
            RestarVida(VidaDis);
        }if (Vida < 1){
            Comida = 0;
            player.SendMessage("cancelarAni",false);
            CancelInvoke("actua");
            GameOver();
        }if((int)Vida >= 100){
            //EstadoVida.SendMessage("cambio",5);
        }if ((int)Vida <= 75 && (int)Vida <100){
           // EstadoVida.SendMessage("cambio", 1);
        }if ((int)Vida <= 50 && (int)Vida <= 74){
            //EstadoVida.SendMessage("cambio", 2);
        }if ((int)Vida <= 25 && (int)Vida <= 49){
            //EstadoVida.SendMessage("cambio", 3);
        }if (Vida < 1){
           // EstadoVida.SendMessage("cambio", 4);
            Energia = 0;
            Agua = 0;
        }{if ((int)Energia >= 100){
             //EstadoEnergia.SendMessage("cambio", 5);
             //player.SendMessage("rectificar", true);
            }
            if ((int)Energia <= 75 && (int)Energia < 100){
            //EstadoEnergia.SendMessage("cambio", 1);
                //player.SendMessage("rectificar", true);
            }
            if ((int)Energia <= 50 && (int)Energia <= 74){
           // EstadoEnergia.SendMessage("cambio", 2);
            }
            if ((int)Energia <= 25 && (int)Energia <= 49){
            //EstadoEnergia.SendMessage("cambio", 3);
            }
            if (Energia < 1){
            //EstadoEnergia.SendMessage("cambio", 4);
                //player.SendMessage("rectificar", false);
            }
        }
        if (Agua > 0){
            RestarAgua(AguaADis);
        }if (Agua >= 25 && estado==false){
            SumarEnergia(EnergiaAu);
        }if (Energia <= 80){
            RestarAgua(AguaDis2);
        }if (estado == true){
            RestarEnergia(EnergiaDis);
        }if(Energia<100){
            energiaObj.SetActive(true);
        }else{
            energiaObj.SetActive(false);
        } if (Agua == 0){
            RestarEnergia((float)EnergiaDis * (float)2.5);
        }
        //Rectificacion de las estadisticas
        Agua = Mathf.Clamp(Agua, 0, 100);
        Energia = Mathf.Clamp(Energia, 0, 100);
        Comida = Mathf.Clamp(Comida, 0, 100);
        Vida = Mathf.Clamp(Vida, 0, 100);
        //Asignacion de las estadisticas a la interfaz grafica
        AguaActual.text = ((int)Agua).ToString() + ' ' + '%';
        EnergiaActual.text = ((int)Energia).ToString() + ' ' + '%';
        VidaActual.text = ((int)Vida).ToString()+' ' + '%';
        ComidaActual.text = ((int)Comida).ToString()+' ' + '%';
        //Invocacion de la funcion para realizar las actualizaciones de las estadisticas
        Invoke("actua", velocidad);
        //-----------\\
    }
    //-------------------------------------------------------------------------------------
    public bool corriendo(bool validar){
        estado = validar;
        return estado;
    }
    //-------------------------------------------------------------------------------------
    public void GameOver(){
        final.SetActive(true);
        jugador.GetComponent<Mov>().enabled = false;
        vidaStat.SetActive(false);
        energiaStat.SetActive(false);
        aguaStat.SetActive(false);
        comidaStat.SetActive(false);
    }
    //-------------------------------------------------------------------------------------
    public void SumarVida(float valor)
    {
        Vida += valor;
    }
    //-------------------------------------------------------------------------------------
    public void SumarComida(float valor)
    {
        Comida += valor;
    }
    //-------------------------------------------------------------------------------------
    public void RestarVida(float valor)
    {
        Vida -= valor;
    }
    //-------------------------------------------------------------------------------------
    public void RestarComida(float valor)
    {
        Comida -= valor;
    }
    //-------------------------------------------------------------------------------------
    public void SumarAgua(float valor)
    {
        Agua += valor;
    }
    //-------------------------------------------------------------------------------------
    public void SumarEnergia(float valor)
    {
        Energia += valor;
    }
    //-------------------------------------------------------------------------------------
    public void RestarAgua(float valor)
    {
        Agua -= valor;
    }
    //-------------------------------------------------------------------------------------
    public void RestarEnergia(float valor){
        Energia -= valor;
    }
    //-------------------------------------------------------------------------------------
    // Use this for initialization
    void Start () {
        ComidaDis2 = 2 * ComidaDis;
        actua();
        AguaDis2 = (float)2.5*AguaADis;
        estado = false;
    }

    // Update is called once per frame
    void Update() {
        
    }
}
