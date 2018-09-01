using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] SceneLoader sceneLoader;
    MusicPlayer musicPlayer;

	// Use this for initialization
	void Start () {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
	}
	
	// Update is called once per frame
	void Update () {
        musicPlayer.setVolume(volumeSlider.value);
	}

    public void SaveAndExit(){
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);

        sceneLoader.LoadScene("01a StartMenu");
    }
}
