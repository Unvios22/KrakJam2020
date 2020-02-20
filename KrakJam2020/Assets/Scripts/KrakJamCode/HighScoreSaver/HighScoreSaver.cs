using System;
using System.Collections;
using System.Collections.Generic;
using highScore;
using TMPro;
using UnityEngine;

public class HighScoreSaver : MonoBehaviour{
    [SerializeField] TMP_InputField playerInputField;
    [SerializeField] private TextMeshProUGUI pointsText;
    
    private HighScore _highScore;
   
    private void Start(){
        _highScore = GameObject.FindGameObjectWithTag(Tags.HIGH_SCORE).GetComponent<HighScore>();
        pointsText.text = "Your score: " + _highScore.HighScoreEntry.Score;
    }

    public void SaveHighScore(){
        _highScore.SaveScore(playerInputField.text);
        GetComponent<SceneSwitcher>().SwitchScene();
    }
}
