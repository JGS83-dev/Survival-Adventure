using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsInven : MonoBehaviour {
    public float consMan;
    public float consMelo;
    public float consSandia;
    public float ManAl, MeloAl, SanAl;
    public GameObject player;
    public GameObject invenCons;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Manzana(){
        player.SendMessage("SumarComida", consMan);
        ManAl -= 1;
        //invenCons.SendMessage("",);
    }
    void Melocoton(){
        player.SendMessage("SumarComida", consMelo);
        MeloAl -= 1;
        //invenCons.SendMessage("",);
    }
    void Sandia(){
        player.SendMessage("SumarComida", consSandia);
        SanAl -= 1;
        //invenCons.SendMessage("",);
    }
}
