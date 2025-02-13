using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSound : MonoBehaviour
{
    float power;
    public float power1;
    public bool musuc;
    public MusicSound next;
    void Start()
    {
        if (!musuc) { power = Magazine_data.sound; }
        else { power = Magazine_data.music; }
        if (power != power1) { gameObject.SetActive(false); }
    }
    public void Ñhange(float i)
    {
        power = i;
        if (!musuc) { Magazine_data.sound = power; }
        else { Magazine_data.music = power; }
        next.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
