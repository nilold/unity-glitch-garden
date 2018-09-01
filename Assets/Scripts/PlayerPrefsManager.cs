using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFICULTY_KEY = "dificulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume){
        if(volume >= 0f && volume <= 1f){
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Tried to set volume out of range: " + volume.ToString());
        }
    }

    public static float GetMasterVolume(){
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }


    public static void UnlockLevel(int level){
        if(level >= 0 && level < Application.levelCount){
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        }else{
            Debug.LogError("Tried to unlock level not in build order");
        }
    }

    public static void LockLevel(int level)
    {
        if (level >= 0 && level < Application.levelCount)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 0);
        }
        else
        {
            Debug.LogError("Tried to lock level not in build order");
        }
    }

    public static bool IsLevelUnlocked(int level){
        return PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1;
    }

    public static void SetDificulty(float dificulty){
        if(dificulty >= 0f && dificulty <= 1f){
            PlayerPrefs.SetFloat(DIFICULTY_KEY, dificulty);
        }else{
            Debug.LogError("Tried to set invalid value of dificulty: " + dificulty.ToString());
        }
    }

    public static float GetDificulty(){
        return PlayerPrefs.GetFloat(DIFICULTY_KEY);
    }
}
