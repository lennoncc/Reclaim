using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adapted from LocationTrigger.cs from Exercise 1

public class MusicSwitcher : MonoBehaviour
{
    [SerializeField] private string musicTrack = "BattleMusic";
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other && other.tag == "Camber")
        {
            Debug.Log(other.tag);
            FindObjectOfType<SoundManager>().PlayMusicTrack(this.musicTrack);
        }
        
    }
}
