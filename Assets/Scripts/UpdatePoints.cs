using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePoints : MonoBehaviour {

    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Score: " + GamePlayManager.points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + GamePlayManager.points.ToString();
    }
}
