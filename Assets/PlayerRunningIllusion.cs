using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningIllusion : MonoBehaviour {

    public float speed = 10;
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 pos = transform.position;

        pos.z -= speed * Time.deltaTime;
        transform.position = pos;
	}
}
