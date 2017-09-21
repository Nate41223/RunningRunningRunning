﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
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
