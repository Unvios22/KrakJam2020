using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour{
	
	[SerializeField] private string sceneSwitchTo;

	public void SwitchScene(){
		if (SceneManager.GetActiveScene().name == "MainGameScene") {
			if (Math.Abs(Time.timeScale) < 0.01) {
				Time.timeScale = 1;
				EventManager.OnGameUnpausedEvent();
			}
			EventManager.OnGameSceneExitedEvent();
		}
		SceneManager.LoadScene(sceneSwitchTo);
	}

	public void ExitGame(){
		Application.Quit(0);
	}
}