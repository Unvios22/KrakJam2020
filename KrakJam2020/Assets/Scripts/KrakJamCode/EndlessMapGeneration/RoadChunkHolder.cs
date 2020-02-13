using System.Collections.Generic;
using healthPointSystem;
using highScore;
using Obstacle;
using Sirenix.Utilities;
using UnityEngine;

namespace EndlessMapGeneration{
	public class RoadChunkHolder : MonoBehaviour{
		[SerializeField] HighScore _highScore;
		[SerializeField] HealthPointsSystem _healthPointsSystem;
		[SerializeField] private FloatingScoreSpawner floatingScoreSpawner;
		[SerializeField] List<RoadObstacle> roadObstaclesOnLeft;
		[SerializeField] List<RoadObstacle> roadObstaclesOnRight;
		[SerializeField] List<GameObject> housesOnLeft;
		[SerializeField] List<GameObject> housesOnRight;

		[SerializeField] PropSpawner leftRoadChunk;
		[SerializeField] PropSpawner rightRoadChunk;
		[SerializeField] HouseSpawner leftHouseChunk;
		[SerializeField] HouseSpawner rightHouseChunk;
		
		[Range(0, 1)] [SerializeField] float chanceToSpawnProp;

		public void SpawnObjectsOnChunk(){
			SpawnOnSpawner(leftRoadChunk, roadObstaclesOnLeft);
			SpawnOnSpawner(rightRoadChunk, roadObstaclesOnRight);
			SpawnOnSpawner(leftHouseChunk, housesOnLeft);
			SpawnOnSpawner(rightHouseChunk, housesOnRight);
		}

		void SpawnOnSpawner(PropSpawner propSpawner, List<RoadObstacle> propList){
			if(propList.IsNullOrEmpty()){
				return;
			}
			propSpawner.SpawnRandomProp(propList, _highScore, _healthPointsSystem, floatingScoreSpawner, chanceToSpawnProp);
		}

		void SpawnOnSpawner(HouseSpawner houseSpawner, List<GameObject> propList){
			if(propList.IsNullOrEmpty()){
				return;
			}
			
			houseSpawner.SpawnRandomHouse(propList);
		}
		
		public HighScore HighScore{
			set => _highScore = value;
		}
		public HealthPointsSystem HealthPointsSystem{
			set => _healthPointsSystem = value;
		}

		public FloatingScoreSpawner UiDisplayManger {
			set => floatingScoreSpawner = value;
		}
	}
}