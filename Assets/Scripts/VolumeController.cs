using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// This code was written by following this tutorial: https://www.youtube.com/watch?v=C1gCOoDU29M

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer myAudioMixer;
    [SerializeField] private string Slider;

    public void SetVolume(float sliderValue)
    {
        myAudioMixer.SetFloat(this.Slider, Mathf.Log10(sliderValue) * 20);
    }
}
