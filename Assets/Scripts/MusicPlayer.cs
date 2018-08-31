using System.Collections;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;
    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource music;

	void Start () {
        if(instance != null && instance != this){
            Destroy(gameObject);
        } else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            PlayMusic(startClip);
        }
    }

    private void PlayMusic(AudioClip clip)
    {
        music.clip = clip;
        music.loop = true;
        music.Play();
    }

    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("Music player loaded level " + level);

        music.Stop();

        AudioClip clip = null;

        if(level == 0){
            clip = startClip;
        } else if (level == 1){
            clip = gameClip;
            music.volume = 0.1f;
        } else if (level ==2){
            clip = endClip;
        }
        PlayMusic(clip);
    }

}
