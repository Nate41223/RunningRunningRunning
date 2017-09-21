using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLevel : MonoBehaviour {

    TextMesh text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<TextMesh>();
        text.text = GamePlayManager.level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GamePlayManager.level.ToString();
    }
}
