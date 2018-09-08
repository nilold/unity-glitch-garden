using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSartVolume : MonoBehaviour {

    private MusicPlayer musicPlayer;

	void Start () {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer){
            musicPlayer.setVolume(PlayerPrefsManager.GetMasterVolume());
        } else{
            Debug.LogWarning("No musicManager found");
        }

	}
	
	void Update () {
		
	}
}
