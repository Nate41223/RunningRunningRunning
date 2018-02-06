using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLevel : MonoBehaviour {

    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Level: " + GamePlayManager.level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Level: " + GamePlayManager.level.ToString();
    }
}
