using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovingUp : MonoBehaviour{
    [SerializeField] float speed;

    void Update(){
        if (Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.up * (Time.deltaTime * speed));
        }
    }
}
