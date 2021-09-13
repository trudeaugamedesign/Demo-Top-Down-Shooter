using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    
    private Transform target;
    public float speed = 2f;

    void Start() {
        target = Player.instance.camTarget;
    }

    void LateUpdate() {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, target.position.x, speed * Time.deltaTime), 
            Mathf.Lerp(transform.position.y, target.position.y, speed * Time.deltaTime),
            transform.position.z
        );
    }
}
