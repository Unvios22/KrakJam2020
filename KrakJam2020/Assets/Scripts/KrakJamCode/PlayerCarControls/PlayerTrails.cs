using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrails : MonoBehaviour{
    [SerializeField] private List<TrailRenderer> trails;

    public void ActivateTrails(){
        foreach (var trail in trails){
            trail.emitting = true;
        }
    }
    
    public void DeactivateTrails(){
        foreach (var trail in trails){
            trail.emitting = false;
        }
    }
}
