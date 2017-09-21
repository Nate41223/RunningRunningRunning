using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsInput : MonoBehaviour {
	
	// Controls Instructions Input Screen
    // SPACE to play
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
