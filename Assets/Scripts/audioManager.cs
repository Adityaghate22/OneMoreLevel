using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music Playlist")]
    public List<AudioClip> musicTracks;

    public AudioClip Door; // Example SFX
    public AudioClip die;
    public AudioClip jump;
    public AudioClip traps;


    private int currentTrackIndex = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayCurrentTrack();
    }

    void Update()
    {
        if (!musicSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    void PlayCurrentTrack()
    {
        if (musicTracks.Count == 0) return;

        musicSource.clip = musicTracks[currentTrackIndex];
        musicSource.Play();
    }

    public void PlayNextTrack()
    {
        currentTrackIndex++;

        if (currentTrackIndex >= musicTracks.Count)
            currentTrackIndex = 0; // loop playlist

        PlayCurrentTrack();
    }
}
