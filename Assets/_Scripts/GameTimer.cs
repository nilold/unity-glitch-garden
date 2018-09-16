using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    Slider slider;
    AudioSource audioSource;
    SceneLoader sceneLoader;
    GameObject winLabel;
    private bool isLevelOver = false;

    public float levelSeconds = 120f;


	// Use this for initialization
	void Start ()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        FindWinLabel();
    }

    private void FindWinLabel()
    {
        winLabel = GameObject.Find("You Won");
        if (winLabel)
        {
            winLabel.SetActive(false);
        } else {
            Debug.LogError("Add Win Label Text UI to scene");
        }
    }

    // Update is called once per frame
    void Update () {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;

        if((Time.timeSinceLevelLoad > levelSeconds) && !isLevelOver)
        {
            EndCurrentLevel();
        }
    }

    private void EndCurrentLevel()
    {
        isLevelOver = true;
        audioSource.Play();
        Invoke("LoadNextLevel", audioSource.clip.length);
        winLabel.SetActive(true);
    }

    void LoadNextLevel(){
        sceneLoader.LoadNextScene();
    }
}
