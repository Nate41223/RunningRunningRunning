using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSlow : MonoBehaviour {

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = "Stop Time: " + GamePlayManager.slowPowerUps.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "Stop Time: " + GamePlayManager.slowPowerUps.ToString();
	}
}
