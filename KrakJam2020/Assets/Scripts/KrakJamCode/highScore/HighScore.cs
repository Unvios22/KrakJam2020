using System;
using System.Collections.Generic;
using System.IO;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace highScore{
	public class HighScore : MonoBehaviour{
		
		[ShowInInspector] HighScoreEntry _highScoreEntry;
		[ShowInInspector] string _highScoreFilePath = "../HighScores.json";
		[ShowInInspector] List<HighScoreEntry> _highScoreEntries = new List<HighScoreEntry>();
		
		DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, 
			DateTimeKind.Utc);

		private void Awake(){
			DontDestroyOnLoad(gameObject);
		}
		
		void Start(){
			LoadHighScoresFromFile();
			InitializeNewGame();//TODO powinno byc wywolane po nowej gra
		}

		public void SaveScore(string playerName){
			SaveNewScore(playerName);
			SaveHighScoresToFile();
		}

		/**
		 * Initialize new HighScoreEntry with playerName
		 */
		public void InitializeNewGame(){
			_highScoreEntry = new HighScoreEntry{
				PlayerName = "",
				Score = 0,
				MillisecondsOnPlayStart = (long) (DateTime.UtcNow - epochStart).TotalMilliseconds
			};
		}
		/**
		 * Adds score to actual HighScoreEntry
		 */
		public void AddScore(int score){
			_highScoreEntry.Score += score;
		}

		/**
		 * Saves score to list
		 */
		public void SaveNewScore(string playerName){
			_highScoreEntry.PlayerName = playerName;
			_highScoreEntry.MillisecondsOnPlayEnd = (long) (DateTime.UtcNow - epochStart).TotalMilliseconds;
			_highScoreEntries.Add(_highScoreEntry);
		}
		
		[Button]
		void SaveHighScoresToFile(){
			var bytes = SerializationUtility.SerializeValue(_highScoreEntries, DataFormat.JSON);
			File.WriteAllBytes(_highScoreFilePath, bytes);
		}
		
		[Button]
		void LoadHighScoresFromFile(){
			var bytes = File.ReadAllBytes(_highScoreFilePath);
			_highScoreEntries = SerializationUtility
				.DeserializeValue<List<HighScoreEntry>>(bytes, DataFormat.JSON);
		}

		[Button]
		void ClearHighScores(){
			_highScoreEntries.Clear();
		}

		[Button]
		void RemoveHighScoreFile(){
			File.Delete(_highScoreFilePath);
		}

		[Button]
		void AddTestHighScoreEntry(){
			Debug.Log("Added new Score");
			var entry = new HighScoreEntry{
				PlayerName = "PlayerName",
				Score = 1000,
				MillisecondsOnPlayStart = 987654321,
				MillisecondsOnPlayEnd = 1987654321
			};
			_highScoreEntries.Add(entry);
		}

		[Button]
		void TestEntriesSort(){
			var sortedList = GetEntriesSortedByScore();
			foreach(var entry in sortedList){
				Debug.Log(entry.Score);
			}
		}

		public List<HighScoreEntry> GetEntriesSortedByScore(){
			_highScoreEntries.Sort((o1, o2) => o2.Score.CompareTo(o1.Score));
			return _highScoreEntries;
		}

		public HighScoreEntry HighScoreEntry => _highScoreEntry;

		public List<HighScoreEntry> HighScoreEntries => _highScoreEntries;
	}
}