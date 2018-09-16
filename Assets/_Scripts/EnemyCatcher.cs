using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCatcher : MonoBehaviour {

    SceneLoader sceneLoader;
    public int lives = 5;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Attacker>()){
            lives--;
        }
        if(lives == 0){
            sceneLoader.LoadScene("03b LoseScreen");
        }
    }
}
