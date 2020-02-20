using healthPointSystem;
using highScore;
using TMPro;
using UnityEngine;

public class PlayerUiManager : MonoBehaviour{
	[SerializeField] TextMeshProUGUI timeRemainingDisplayText;
	[SerializeField] TextMeshProUGUI pointsDisplayText;
	[SerializeField] TextMeshProUGUI HpDisplayText;
	
	[SerializeField] HighScore _highScore;
	[SerializeField] HealthPointsSystem _healthPointsSystem;
	[SerializeField] GameEnder _gameEnder;
	
	void Update() {
		//TODO: execute methods from proper places/through events
		UpdateRemainingTimeText();
		UpdatePointsDisplayText();
		// UpdateHpDisplayText();
	}

	public void UpdateRemainingTimeText() {
		timeRemainingDisplayText.text = "RemainingTime: " + _gameEnder.RemainingGameTime.ToString();
	}

	public void UpdatePointsDisplayText() {
		pointsDisplayText.text = "Score: " + _highScore.HighScoreEntry.Score.ToString();
	}

	public void UpdateHpDisplayText() {
		HpDisplayText.text = "HP: " + _healthPointsSystem.MaxHp.ToString();
	}
}
