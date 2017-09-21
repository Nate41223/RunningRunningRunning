using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverInput : MonoBehaviour {
	
	// Controls the Input for the Game Over screen
    // SPACE to play again
    // ESC to quit the game
	void Update () {
		if (Input.GetButtonDown("Jump"))
        {
            GamePlayManager.resetGame();
            SceneManager.LoadScene("GameScene");
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }
}
