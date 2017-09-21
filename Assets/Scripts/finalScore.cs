using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalScore : MonoBehaviour {

    TextMesh text;

    // Applies the final score to the game over screen
    void Start () {
        text = GetComponent<TextMesh>();
        text.text = "Final Score: " + GamePlayManager.points.ToString();
    }
}
