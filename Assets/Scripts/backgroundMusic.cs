using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic : MonoBehaviour {

	// Starts the background music for the game, and can't be destroyed on a scene switch
	void Start () {
        DontDestroyOnLoad(gameObject);
        GetComponent<AudioSource>().Play();
    }
}
