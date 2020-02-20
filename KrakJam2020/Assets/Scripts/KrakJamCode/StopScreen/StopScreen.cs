﻿using UnityEngine;

public class StopScreen : MonoBehaviour{

	[SerializeField] private GameObject pauseGameCanvas;
	private bool _isPaused;
	private void Update(){
		if (!Input.GetKeyDown(KeyCode.Escape)) return;
		if (!_isPaused){
			PauseGame();
		}
		else{
			UnPauseGame();
		}
	}

	private void PauseGame(){
		Time.timeScale = 0;
		pauseGameCanvas.SetActive(true);
		_isPaused = true;
		EventManager.OnGamePausedEvent();
	}

	public void UnPauseGame(){
		Time.timeScale = 1;
		pauseGameCanvas.SetActive(false);
		_isPaused = false;
		EventManager.OnGameUnpausedEvent();
	}
}
