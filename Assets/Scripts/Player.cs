using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	// Updates player position in the Gmeplay Manager script every frame
	void Update () {
        GamePlayManager.playerPosition = transform.position;
    }
}
