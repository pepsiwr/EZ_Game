using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void setvolume(float volume)
    {
        audioMixer.SetFloat("volume", volume); //volume ตัวหลังตั้งให้เหมือนใน audio mixer
    }
}
