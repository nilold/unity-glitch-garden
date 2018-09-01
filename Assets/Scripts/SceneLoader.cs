//using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float splashScreenTime = 3.5f;

    private void Start()
    {
        //LoadNextSceneAfter();
        Invoke("LoadNextScene", splashScreenTime);
    }

    private void LoadNextSceneAfter()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            StartCoroutine(ExitSplashScreen(splashScreenTime));
        }
    }

    private IEnumerator ExitSplashScreen(float delay){
        yield return new WaitForSeconds(delay);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
    }

    public void LoadLastScene(){
        SceneManager.LoadScene(2);
    }

    public void LoadFirstScene(){
        Debug.Log("load first scene");
        SceneManager.LoadScene(0);
    }

    public void QuitGame(){
        Application.Quit();
    }

}
