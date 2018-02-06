using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBreak : MonoBehaviour {

    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Invincibility: " + GamePlayManager.breakPowerUps.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Invincibility: " + GamePlayManager.breakPowerUps.ToString();
    }
}
