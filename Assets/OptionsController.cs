using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] SceneLoader sceneLoader;
    MusicPlayer musicPlayer;

    // Use this for initialization
    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeVolume()
    {
        if (musicPlayer)
            musicPlayer.setVolume(volumeSlider.value);
    }

    public void SetDefaults(){
        volumeSlider.value = PlayerPrefsManager.defaultMasterVolume;
        difficultySlider.value = PlayerPrefsManager.defaultDifficulty;
    }


    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);

        sceneLoader.LoadScene("01a StartMenu");
    }
}
