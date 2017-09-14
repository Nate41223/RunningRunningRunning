using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingManager : MonoBehaviour {

    public AABBCollider player;
    static public List<AABBCollider> Walls = new List<AABBCollider>();
    static public List<AABBCollider> Floors = new List<AABBCollider>();


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        DoCollisionDetection();
	}
}
