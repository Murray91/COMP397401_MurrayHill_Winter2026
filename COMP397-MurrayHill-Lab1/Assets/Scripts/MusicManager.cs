using UnityEngine;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    public List<AudioClip> musicPlaylist;  // List of songs to play
    public AudioSource audioSource;        // Assign an AudioSource in inspector

    private int currentTrack = 0;

    void Start()
    {
        if (musicPlaylist.Count > 0)
        {
            PlayCurrentTrack();
        }
    }

    void Update()
    {
        // When a track finishes, play the next one
        if (!audioSource.isPlaying && musicPlaylist.Count > 0)
        {
            NextTrack();
        }
    }

    void PlayCurrentTrack()
    {
        audioSource.clip = musicPlaylist[currentTrack];
        audioSource.Play();
    }

    void NextTrack()
    {
        currentTrack = (currentTrack + 1) % musicPlaylist.Count; // loops playlist
        PlayCurrentTrack();
    }
}