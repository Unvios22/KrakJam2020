using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour {
    [SerializeField] private AudioClip[] musicArray;
    [SerializeField] private AudioClip[] pedestrianCollisionSounds;
    [SerializeField] private AudioClip[] truckDriftingSounds;

    [SerializeField] private AudioClip concreteSplashingSound;
    [SerializeField] private AudioClip holeFilledSound;
    [SerializeField] private AudioClip unfilledHoleCollisionSound;
    [SerializeField] private AudioClip obstacleCollisionSound;
    [SerializeField] private AudioClip carCollisionSound;
    [SerializeField] private AudioClip truckColorChangedSound;
    [SerializeField] private AudioClip UiButtonHoverSound;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource concreteSplashingSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource driftingSoundSource;
    [SerializeField] private AudioSource UISoundsSource;

    private void Start() {
        SubscribeToEvents();
    }

    private void SubscribeToEvents() {
        EventManager.GameStartedEvent += PlayMusic;
        EventManager.CarStartedDriftingEvent += PlayTruckDriftingSound;
        EventManager.ObstacleCollidedEvent += PlayObstacleCollisionSound;
        EventManager.CarCollidedEvent += PlayCarCollisionSound;
        EventManager.UnfilledHoleCollidedEvent += PlayUnfilledHoleCollisionSound;
        EventManager.HoleFilledEvent += PlayHoleFilledSound;
        EventManager.PedestrianKilledEvent += PlayPedestrianCollisionSound;
        EventManager.ConcreteStartedSplashingEvent += StartPlayingConcreteSplashingSound;
        EventManager.ConcreteStoppedSplashingEvent += StopPlayingConcreteSplashingSound;
        EventManager.TruckColorChangedEvent += PlayerTruckColorChangedSound;
        EventManager.UiButtonHoverEvent += PlayUiButtonHoverSound;
    }

    private void PlayMusic() {
        var musicToPlay = GetRandomClipFromArray(musicArray);
        musicSource.clip = musicToPlay;
        musicSource.Play();
    }

    private void StartPlayingConcreteSplashingSound() {
        concreteSplashingSource.clip = concreteSplashingSound;
        concreteSplashingSource.Play();
    }

    private void StopPlayingConcreteSplashingSound() {
        concreteSplashingSource.Stop();
    }

    private void PlayHoleFilledSound() {
        sfxSource.PlayOneShot(holeFilledSound);
    }

    private void PlayUnfilledHoleCollisionSound() {
     sfxSource.PlayOneShot(unfilledHoleCollisionSound);   
    }

    private void PlayObstacleCollisionSound() {
        sfxSource.PlayOneShot(obstacleCollisionSound);
    }

    private void PlayCarCollisionSound() {
        sfxSource.PlayOneShot(carCollisionSound);
    }

    private void PlayPedestrianCollisionSound() {
        var clipToPlay = GetRandomClipFromArray(pedestrianCollisionSounds);
        sfxSource.PlayOneShot(clipToPlay);
    }

    private void PlayTruckDriftingSound() {
        var clipToPlay = GetRandomClipFromArray(truckDriftingSounds);
        driftingSoundSource.PlayOneShot(clipToPlay);
    }

    private void PlayerTruckColorChangedSound() {
        UISoundsSource.PlayOneShot(truckColorChangedSound);
    }

    private void PlayUiButtonHoverSound() {
        UISoundsSource.PlayOneShot(UiButtonHoverSound);
    }

    private AudioClip GetRandomClipFromArray(AudioClip[] clipArray) {
        if (clipArray == null) { throw new ArgumentNullException($"clipArray is null!");}
        return clipArray[Random.Range(0, clipArray.Length)];
    }
}
