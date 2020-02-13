using System;
using System.Collections;
using System.Collections.Generic;
using highScore;
using UnityEngine;

public class HighScoreEntriesUI : MonoBehaviour{

	[SerializeField] private ScoreEntryDisplay scoreEntryDisplay;
	[SerializeField] private HighScore highScore;

	private void Start(){
		foreach(var entry in highScore.GetEntriesSortedByScore()){
			var display = Instantiate(scoreEntryDisplay, transform);
			display.highScoreEntry = entry;
			display.RefreshDisplay();
		}
	}
}