using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolume : MonoBehaviour
{
    public bool music;
    void Update()
    {
        if (!music){ gameObject.GetComponent<AudioSource>().volume = Magazine_data.sound; }
        else{ gameObject.GetComponent<AudioSource>().volume = Magazine_data.music; }
    }
}
