using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLives : MonoBehaviour {

    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Lives: " + GamePlayManager.playerLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Lives: " + GamePlayManager.playerLives.ToString();
    }
}
