using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    static MusicPlayer instance = null;
    public AudioClip[] audioClip;
    private AudioSource music;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
        instance = this;
        DontDestroyOnLoad(gameObject);
        music = GetComponent<AudioSource>();
        setVolume(PlayerPrefsManager.GetMasterVolume());
        PlayMusic(audioClip[SceneManager.GetActiveScene().buildIndex]);
        }
    }

    private void PlayMusic(AudioClip clip)
    {
        music.Stop();
        music.clip = clip;
        music.loop = true;
        music.Play();
    }

    public void setVolume(float volume)
    {
        music.volume = volume;
    }

    private void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelClip = audioClip[level];

        if (thisLevelClip)
            PlayMusic(thisLevelClip);

    }

}
