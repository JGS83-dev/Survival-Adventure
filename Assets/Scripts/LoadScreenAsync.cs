using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreenAsync : MonoBehaviour {

    public RadialProgressBar radialBar;
    private AsyncOperation asyncLoad;

    public string sceneToLoad;

    //Presionar enter para seguir
    bool active;


	// Use this for initialization
	void Start () {
        radialBar.OnChange(this.OnRadialBarChange);
        
        StartCoroutine(this.LoadAsyncScene());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            radialBar.OnDone(this.OnRadialBarDone);
        }
    }

    void OnRadialBarChange(float value)
    {
        print("Radial progress is : " + value);
    }

    void OnRadialBarDone()
    {
        print("Radial Progress is Done!");
        asyncLoad.allowSceneActivation = true;
    }

    IEnumerator LoadAsyncScene()
    {
        asyncLoad = SceneManager.LoadSceneAsync(this.sceneToLoad);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            radialBar.SetValue(Mathf.Clamp01(asyncLoad.progress / 0.9f));
            yield return null;
        }
    }
}
