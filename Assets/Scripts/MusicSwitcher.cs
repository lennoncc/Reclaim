using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    [SerializeField] private string musicTrack = "BattleMusic";
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other)
        {
            Debug.Log("playing!");
            FindObjectOfType<SoundManager>().PlayMusicTrack(this.musicTrack);
        }
        
    }
}
