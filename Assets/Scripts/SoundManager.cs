using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource musicsource;

    public static void SetMusicVolume(float volume){
        musicsource.volume = volume;
    }
}
