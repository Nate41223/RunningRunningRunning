using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABBCollider : MonoBehaviour {

    // holds the min and max values for AABB collision
    Vector3 min = Vector3.zero;
    Vector3 max = Vector3.zero;

    // holds half sizes for AABB collision
    public Vector3 halfSize;
	
    // have to calculate min and max on start, otherwise their first frame of collision will be at world origin
    void Start()
    {
        min = transform.position - halfSize;
        max = transform.position + halfSize;
    }

	// Calculates the min and max edges for AABB every frame
	void Update () {
        CalcEdges();
    }
    // Calculates min and max when called
    void CalcEdges()
    {
        min = transform.position - halfSize;
        max = transform.position + halfSize;
    }

    // checks Overlap against any other AABB when called
    public bool CheckOverlap(AABBCollider other)
    {
        if (min.x > other.max.x) return false;
        if (max.x < other.min.x) return false;
        if (min.y > other.max.y) return false;
        if (max.y < other.min.y) return false;
        if (min.z > other.max.z) return false;
        if (max.z < other.min.z) return false;
        return true;
    }
}
