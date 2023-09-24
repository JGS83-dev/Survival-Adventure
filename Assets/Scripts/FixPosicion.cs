using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixPosicion : MonoBehaviour {

    public bool fixEveryFrame;
    SpriteRenderer spr;
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.sortingLayerName = "Player";
        spr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
    }
    void Update()
    {
        if (fixEveryFrame)
        {
            spr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
        }
    }
}
