using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour {
    [SerializeField] private AudioClip[] musicArray;
    
    [SerializeField] private AudioClip holeFilledSound;
    [SerializeField] private AudioClip unfilledHoleCollisionSound;
    [SerializeField] private AudioClip obstacleCollisionSound;
    [SerializeField] private AudioClip carCollisionSound;
    [SerializeField] private AudioClip[] pedestrianCollisionSounds;
    
    [SerializeField] private AudioClip truckSpeedUpSound;
    [SerializeField] private AudioClip truckSlowDownSound;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource driftingSoundSource;
    [SerializeField] private AudioSource truckSoundsSource;

    public void PlayMusic() {
        var musicToPlay = GetRandomClipFromArray(musicArray);
        musicSource.clip = musicToPlay;
        musicSource.Play();
    }

    public void PlayHoleFilledSound() {
        sfxSource.PlayOneShot(holeFilledSound);
    }

    public void PlayUnfilledHoleCollisionSound() {
     sfxSource.PlayOneShot(unfilledHoleCollisionSound);   
    }

    public void PlayObstacleCollisionSound() {
        sfxSource.PlayOneShot(obstacleCollisionSound);
    }

    public void PlayCarCollisionSound() {
        sfxSource.PlayOneShot(carCollisionSound);
    }

    public void PlayPedestrianCollisionSound() {
        var clipToPlay = GetRandomClipFromArray(pedestrianCollisionSounds);
        sfxSource.PlayOneShot(clipToPlay);
    }

    public void StartPlayingTruckSpeedUpSound() {
        
    }
    
    private AudioClip GetRandomClipFromArray(AudioClip[] clipArray) {
        if (clipArray == null) { throw new ArgumentNullException($"clipArray is null!");}
        return clipArray[Random.Range(0, clipArray.Length)];
    }
}
