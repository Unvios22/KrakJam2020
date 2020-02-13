using UnityEngine;

public class PlayerMovementCollidersManager : MonoBehaviour {
    [SerializeField] Transform playerCollidersHolder;
    
    [SerializeField] GameObject verticalColliderPrefab;
    [SerializeField] GameObject horizontalColliderPrefab;

    [SerializeField] float verticalColliderZOffset;
    [SerializeField] float horizontalColliderXOffset;

    [SerializeField] float gizmosSpheresRadius;

    void Start(){
        SpawnColliders();
    }

    void SpawnColliders() {
        var position = transform.position;
        //spawn vertical colliders
        Instantiate(verticalColliderPrefab, new Vector3(position.x, 0f, verticalColliderZOffset),
            verticalColliderPrefab.transform.rotation, playerCollidersHolder);
        Instantiate(verticalColliderPrefab, new Vector3(position.x, 0f, -verticalColliderZOffset),
            verticalColliderPrefab.transform.rotation, playerCollidersHolder);
        
        //spawn horizontal colliders
        Instantiate(horizontalColliderPrefab, new Vector3(horizontalColliderXOffset, 0f, position.z),
            horizontalColliderPrefab.transform.rotation, playerCollidersHolder);
        Instantiate(horizontalColliderPrefab, new Vector3(-horizontalColliderXOffset, 0f, position.z),
            horizontalColliderPrefab.transform.rotation, playerCollidersHolder);
    }

    void OnDrawGizmos() {
        var position = transform.position;
        Gizmos.DrawWireSphere(new Vector3(position.x, 0f, verticalColliderZOffset),gizmosSpheresRadius);
        Gizmos.DrawWireSphere(new Vector3(position.x, 0f, -verticalColliderZOffset), gizmosSpheresRadius);
        Gizmos.DrawWireSphere(new Vector3(position.x + horizontalColliderXOffset, 0f, position.z),gizmosSpheresRadius);
        Gizmos.DrawWireSphere(new Vector3(position.y - horizontalColliderXOffset, 0f, position.z),gizmosSpheresRadius);
    }
}
