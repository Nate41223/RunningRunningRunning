using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAttract : MonoBehaviour {

    TextMesh text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<TextMesh>();
        text.text = GamePlayManager.attractPowerUps.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GamePlayManager.attractPowerUps.ToString();
    }
}
