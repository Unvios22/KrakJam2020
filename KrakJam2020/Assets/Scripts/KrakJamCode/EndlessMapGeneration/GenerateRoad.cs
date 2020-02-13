using EndlessMapGeneration;
using healthPointSystem;
using highScore;
using UnityEngine;


public class GenerateRoad : MonoBehaviour{
    [SerializeField] RoadChunkHolder roadPrefab;
    [SerializeField] Transform roadsHolder;
    [SerializeField] Transform startingTile;
    [SerializeField] Transform playerTransform;
    [SerializeField] float minDistanceToSpawnNextRoadTile;
    [SerializeField] float timeToDestroy;
    [SerializeField] HighScore highScore;
    [SerializeField] HealthPointsSystem healthPointsSystem;
    [SerializeField] FloatingScoreSpawner floatingScoreSpawner;

    Vector3 _lastEndPointLocation;

    void Awake(){
        _lastEndPointLocation = startingTile.Find("EndPoint").position;
        SpawnRoadTile();
        SpawnRoadTile();
        SpawnRoadTile();
        
    }

    void Update(){
        if (Vector3.Distance(playerTransform.position,_lastEndPointLocation) < minDistanceToSpawnNextRoadTile){
            SpawnRoadTile();
        }
    }

    void SpawnRoadTile(){
        var lastRoadTileTransform = SpawnRoadTile(_lastEndPointLocation);
        _lastEndPointLocation = lastRoadTileTransform.Find("EndPoint").position;
    }

    Transform SpawnRoadTile(Vector3 spawnLocation){
        var instantiatedObject = Instantiate(roadPrefab, spawnLocation, Quaternion.identity,roadsHolder);
        instantiatedObject.HighScore = highScore;
        instantiatedObject.HealthPointsSystem = healthPointsSystem;
        instantiatedObject.UiDisplayManger = floatingScoreSpawner;
        instantiatedObject.SpawnObjectsOnChunk();
        
		Destroy(instantiatedObject,timeToDestroy);
        return instantiatedObject.transform;
    }

}
