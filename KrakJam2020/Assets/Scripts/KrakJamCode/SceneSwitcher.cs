using System.Collections;
using System.Collections.Generic;
using highScore;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour{
	
	[SerializeField] private string sceneSwitchTo;

	public void SwitchScene(){
		SceneManager.LoadScene(sceneSwitchTo);
	}

	public void ExitGame(){
		Application.Quit(0);
	}
}