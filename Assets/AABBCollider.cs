using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABBCollider : MonoBehaviour {

    Vector3 min = Vector3.zero;
    Vector3 max = Vector3.zero;

    public Vector3 halfSize;
	
	// Update is called once per frame
	void Update () {
        CalcEdges();
    }

    void CalcEdges()
    {
        min = transform.position - halfSize;
        max = transform.position + halfSize;
    }

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
