using System.Collections.Generic;
using UnityEngine;

namespace EndlessMapGeneration{
	public class HouseSpawner : MonoBehaviour{
		[SerializeField] float offsetX;
		[SerializeField] float offsetZ;

		public void SpawnRandomHouse(List<GameObject> propList){
			var propToSpawn = GetRandomProp(propList);
			var randomPosition = GetRandomPosition();
			var prop = Instantiate(propToSpawn, randomPosition, propToSpawn.transform.rotation);
			Destroy(prop, 10f);
		}

		GameObject GetRandomProp(List<GameObject> propList){
			return propList[Random.Range(0, propList.Count)];
		}

		Vector3 GetRandomPosition(){
			var position = transform.position;
			var posX = position.x + Random.Range(-offsetX, offsetX);
			var posY = position.y;
			var posZ = position.z + Random.Range(-offsetZ, offsetZ);
			return new Vector3(posX, posY, posZ);
		}
	}
}