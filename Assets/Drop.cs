using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Drop : MonoBehaviour {
    public Transform muePos;
    public GameObject[] drop;
    float num;
    // Use this for initialization
    private void Awake(){
        Assert.IsTrue(muePos);
    }
    void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}
    public void dropFun(){
        num = Random.Range(1, 7);
        if (num == 1){ Instantiate(drop[0], muePos.position, muePos.rotation);}
        if (num == 2) { Instantiate(drop[1], muePos.position, muePos.rotation); }
        if (num == 3) { Instantiate(drop[2], muePos.position, muePos.rotation); }
        if (num == 4) {}
        if (num == 5) {}
        else {}
    }
}
