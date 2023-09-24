using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour {

    public Transform spawnPos;
    public GameObject spawnObj;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(spawnObj, spawnPos.position, spawnPos.rotation);
        }
    }
}
