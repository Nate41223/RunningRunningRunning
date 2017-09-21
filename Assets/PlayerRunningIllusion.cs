using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningIllusion : MonoBehaviour {
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 pos = transform.position;

        pos.z -= GamePlayManager.speed * Time.deltaTime;
        transform.position = pos;
	}
}
