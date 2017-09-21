using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalScore : MonoBehaviour {

    TextMesh text;

    // Use this for initialization
    void Start () {
        text = GetComponent<TextMesh>();
        text.text = "Final Score: " + GamePlayManager.points.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
