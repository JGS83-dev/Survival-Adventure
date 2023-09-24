using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class FollowPlayer : MonoBehaviour {

    GameObject player;

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){
        if (player != null){
            transform.position = new Vector3(
                player.transform.position.x,
                player.transform.position.y,
                transform.position.z);
        }
    }
}