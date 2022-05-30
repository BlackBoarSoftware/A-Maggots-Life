using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake() 
    {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;//find all MusicPlayer objects as an array, and store said array's length
        if(numMusicPlayer > 1) //if length is more than one (meaning that a MusicPlayer already exists), destroy this gameObject
        {
            Destroy(gameObject);
        }
        else //else override unity's default behavior, and don't destroy the gameObject on load.
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
