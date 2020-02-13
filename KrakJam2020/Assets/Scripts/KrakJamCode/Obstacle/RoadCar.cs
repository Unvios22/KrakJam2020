using System;
using System.Collections.Generic;
using Obstacle;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadCar : RoadObstacle {
	[SerializeField] float roadMovementSpeed;
	[SerializeField] List<GameObject> carModels;
	[SerializeField] float carModelYRotation;

	void Awake(){
		LoadRandomCarModel();
	}

	void LoadRandomCarModel(){
		var randomCarModel = carModels[Random.Range(0, carModels.Count)];
		var instantiatedCarModel = Instantiate(randomCarModel, gameObject.transform);
		var carTransform = instantiatedCarModel.transform;
		instantiatedCarModel.transform.RotateAround(carTransform.position,carTransform.up,carModelYRotation);
	}

	void Update() {
		transform.Translate(Vector3.left * (roadMovementSpeed * Time.deltaTime), Space.World);
	}
}
