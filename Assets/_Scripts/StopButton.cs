using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour {
    SceneLoader sceneLoader;

    // Use this for initialization
    void Start () {
        sceneLoader = FindObjectOfType<SceneLoader>();

    }

    private void OnMouseDown()
    {
        print("STOP");
        sceneLoader.LoadScene("01a StartMenu");
    }
}
