using System.Collections.Generic;
using healthPointSystem;
using highScore;
using Obstacle;
using Sirenix.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EndlessMapGeneration{
	public class PropSpawner : MonoBehaviour{
		[SerializeField] float offsetX;
		[SerializeField] float offsetZ;
		
		public void SpawnRandomProp(List<RoadObstacle> propList, HighScore highScore,
			HealthPointsSystem healthPointsSystem, FloatingScoreSpawner floatingScoreSpawner , float chanceToSpawnProp){
			if(Random.value <= chanceToSpawnProp){
				SpawnRandomProp(propList, highScore, healthPointsSystem, floatingScoreSpawner);
			}
		}
		
		public void SpawnRandomProp(List<RoadObstacle> propList, HighScore highScore,
			HealthPointsSystem healthPointsSystem, FloatingScoreSpawner floatingScoreSpawner){
			var propToSpawn = GetRandomProp(propList);
			var randomPosition = GetRandomPosition(propToSpawn);

			var prop = Instantiate(propToSpawn, randomPosition, propToSpawn.transform.rotation);
			prop.highScore = highScore;
			prop.healthPointsSystem = healthPointsSystem;
			prop.floatingScoreSpawner = floatingScoreSpawner;
			
			Destroy(prop.gameObject, 10f);
		}

		RoadObstacle GetRandomProp(List<RoadObstacle> propList){
			return propList[Random.Range(0, propList.Count)];
		}

		Vector3 GetRandomPosition(RoadObstacle roadObstacle){
			var position = transform.position;
			var posX = position.x + Random.Range(-offsetX, offsetX);
			var posY = position.y + roadObstacle.heightOffset;
			var posZ = position.z + Random.Range(-offsetZ, offsetZ);
			return new Vector3(posX, posY, posZ);
		}

		void OnDrawGizmos(){
			Gizmos.DrawWireCube(transform.position, new Vector3(offsetX * 2, 0, offsetZ * 2));
		}
	}
}