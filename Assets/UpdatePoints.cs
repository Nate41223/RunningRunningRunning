using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePoints : MonoBehaviour {

    TextMesh text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<TextMesh>();
        text.text = GamePlayManager.points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GamePlayManager.points.ToString();
    }
}
