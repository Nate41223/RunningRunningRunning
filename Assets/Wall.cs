using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	void Start () {
        print(transform.position);
        CollidingManager.walls.Add(GetComponent<AABBCollider>());
	}
	
	void OnDestroy () {
        CollidingManager.walls.Remove(GetComponent<AABBCollider>());
    }
}
