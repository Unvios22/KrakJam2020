using System;
using System.Collections;
using System.Collections.Generic;
using highScore;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreEntryDisplay : MonoBehaviour{

	[SerializeField] private TextMeshProUGUI playerNameText;
	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private TextMeshProUGUI timePlayedText;

	public HighScoreEntry highScoreEntry;

	public void RefreshDisplay(){
		playerNameText.text = playerNameText.text + " " + highScoreEntry.PlayerName;
		scoreText.text = scoreText.text + " " + highScoreEntry.Score;
		timePlayedText.text = timePlayedText.text + " " + highScoreEntry.TimePlayedInSeconds();
	}
}