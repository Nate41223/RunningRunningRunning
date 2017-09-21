using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningIllusion : MonoBehaviour {
	
	// Updates every object in the scene to give the illusion of the player moving foreward
	void LateUpdate () {
        Vector3 pos = transform.position;

        pos.z -= GamePlayManager.speed * Time.deltaTime;
        transform.position = pos;
	}
}
