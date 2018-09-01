using System.Collections;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    static MusicPlayer instance = null;
    public AudioClip[] audioClip;
    private AudioSource music;

    void Start()
    {
        //if(instance != null && instance != this){
        //    Destroy(gameObject);
        //} else
        //{
        //instance = this;
        DontDestroyOnLoad(gameObject);
        music = GetComponent<AudioSource>();
        PlayMusic(audioClip[0]);
        //}
    }

    private void PlayMusic(AudioClip clip)
    {
        music.Stop();
        music.clip = clip;
        music.loop = true;
        music.Play();
    }

    private void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelClip = audioClip[level];

        if (thisLevelClip)
            PlayMusic(thisLevelClip);

    }

}
