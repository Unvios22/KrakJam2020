using System;
using highScore;
using Obstacle;
using Sirenix.OdinInspector;
using UnityEngine;

namespace concreteMechanic{
	[RequireComponent(typeof(Rigidbody), typeof(RoadObstacle))]
	public class SplashableByConcrete : MonoBehaviour{
		[SerializeField] bool isSplashed;
		[SerializeField] int scoreGainedBySplashing;
		[SerializeField] HighScore highScore;
		[SerializeField] SpriteRenderer spriteRenderer;
		[SerializeField] Sprite filledHole;

		RoadObstacle _roadObstacle;

		void Start(){
			_roadObstacle = GetComponent<RoadObstacle>();
			highScore = _roadObstacle.highScore;
		}

		public void SplashByConcrete(){
			if(isSplashed){
				return;
			}
			
			isSplashed = true;
			spriteRenderer.sprite = filledHole;
			_roadObstacle.enabled = false;
			highScore.AddScore(scoreGainedBySplashing);
			_roadObstacle.floatingScoreSpawner.SpawnFloatingPointsAmount(scoreGainedBySplashing, transform.position);
		}
	}
}