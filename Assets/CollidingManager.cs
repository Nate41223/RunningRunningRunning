using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingManager : MonoBehaviour {

    public AABBCollider player;
    static public List<AABBCollider> walls = new List<AABBCollider>();
    static public List<AABBCollider> floors = new List<AABBCollider>();


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        DoCollisionDetection();
	}

    private void DoCollisionDetection()
    {
        for (int i = walls.Count - 1; i >= 0; i--)
        {
            if(walls[i].CheckOverlap(player))
            {
                Destroy(walls[i].gameObject);
            }

        }
    }
}
