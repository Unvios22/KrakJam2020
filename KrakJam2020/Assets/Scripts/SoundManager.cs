using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour {
    [BoxGroup("AudioClip arrays")]
    [SerializeField] private AudioClip[] musicArray;
    [SerializeField] private AudioClip[] pedestrianCollisionSounds;
    [SerializeField] private AudioClip[] truckDriftingSounds;    

    [BoxGroup("AudioClips")]
    [SerializeField] private AudioClip concreteSplashingSound;
    [SerializeField] private AudioClip holeFilledSound;
    [SerializeField] private AudioClip unfilledHoleCollisionSound;
    [SerializeField] private AudioClip obstacleCollisionSound;
    [SerializeField] private AudioClip carCollisionSound;
    [SerializeField] private AudioClip truckColorChangedSound;
    [SerializeField] private AudioClip UiButtonHoverSound;
    [SerializeField] private AudioClip UiButtonClickSound;
    
    [BoxGroup("AudioSources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource concreteSoundsSource;
    [SerializeField] private AudioSource CarAndObstacleCollisionsSource;
    [SerializeField] private AudioSource PedestrianCollisionsSource;
    [SerializeField] private AudioSource driftingSoundSource;
    [SerializeField] private AudioSource UISoundsSource;

    [BoxGroup("Snapshots")]
    [SerializeField] private AudioMixerSnapshot NormalGameSnapshot;
    [SerializeField] private AudioMixerSnapshot PausedGameSnapshot;
    [SerializeField] private float SnapshotTransitionTime;

    [BoxGroup("Variable pitch")]
    [SerializeField] private float minDriftingSoundPitch;
    [SerializeField] private float maxDriftingSoundPitch;

    private Coroutine _playMusicCoroutine;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType(GetType()).Length > 1){
            Destroy(gameObject);
        }
    }

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
        EventManager.UiButtonClickEvent += PlayUiButtonClickSound;
        EventManager.GamePausedEvent += GamePaused;
        EventManager.GameUnpausedEvent += GameUnpaused;
        EventManager.GameSceneExitedEvent += StopPlayingMusic;
    }

    private void PlayMusic() {
        _playMusicCoroutine = StartCoroutine(PlayMusicCoroutine());
    }

    private void StopPlayingMusic() {
        musicSource.Stop();
        StopCoroutine(_playMusicCoroutine);
    }

    private IEnumerator PlayMusicCoroutine() {
        for (;;) {
            var musicToPlay = GetRandomClipFromArray(musicArray);
            var clipLength = musicToPlay.length;
            musicSource.clip = musicToPlay;
            musicSource.Play();
            yield return new WaitForSeconds(clipLength);
            musicSource.Stop();
        }
    }

    private void StartPlayingConcreteSplashingSound() {
        concreteSoundsSource.clip = concreteSplashingSound;
        concreteSoundsSource.Play();
    }

    private void StopPlayingConcreteSplashingSound() {
        concreteSoundsSource.Stop();
    }

    private void PlayHoleFilledSound() {
        concreteSoundsSource.PlayOneShot(holeFilledSound);
    }

    private void PlayUnfilledHoleCollisionSound() {
     CarAndObstacleCollisionsSource.PlayOneShot(unfilledHoleCollisionSound);   
    }

    private void PlayObstacleCollisionSound() {
        CarAndObstacleCollisionsSource.PlayOneShot(obstacleCollisionSound);
    }

    private void PlayCarCollisionSound() {
        CarAndObstacleCollisionsSource.PlayOneShot(carCollisionSound);
    }

    private void PlayPedestrianCollisionSound() {
        var clipToPlay = GetRandomClipFromArray(pedestrianCollisionSounds);
        PedestrianCollisionsSource.PlayOneShot(clipToPlay);
    }

    private void PlayTruckDriftingSound() {
        var clipToPlay = GetRandomClipFromArray(truckDriftingSounds);
        var pitch = Random.Range(minDriftingSoundPitch, maxDriftingSoundPitch);
        driftingSoundSource.pitch = pitch;
        driftingSoundSource.PlayOneShot(clipToPlay);
    }

    private void PlayerTruckColorChangedSound() {
        UISoundsSource.PlayOneShot(truckColorChangedSound);
    }

    private void PlayUiButtonHoverSound() {
        UISoundsSource.PlayOneShot(UiButtonHoverSound);
    }

    private void PlayUiButtonClickSound() {
        UISoundsSource.PlayOneShot(UiButtonClickSound);
    }

    private void GamePaused() {
        PausedGameSnapshot.TransitionTo(SnapshotTransitionTime);
    }

    private void GameUnpaused() {
        NormalGameSnapshot.TransitionTo(SnapshotTransitionTime);
    }

    private AudioClip GetRandomClipFromArray(AudioClip[] clipArray) {
        if (clipArray == null) { throw new ArgumentNullException($"clipArray is null!");}
        return clipArray[Random.Range(0, clipArray.Length)];
    }
}
