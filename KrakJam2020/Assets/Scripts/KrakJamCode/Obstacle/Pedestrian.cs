using System.Collections.Generic;
using UnityEngine;

namespace Obstacle{
	public class Pedestrian : MonoBehaviour {
	
		[SerializeField] List<GameObject> models;

		void Awake(){
			LoadRandomModel();
		}

		void LoadRandomModel(){
			var randomPedestrianModel = models[Random.Range(0, models.Count)];
			Instantiate(randomPedestrianModel, gameObject.transform);
		}
	    
	}
}
