﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    Vector3 velocity = new Vector3();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

        if (transform.position.y <= 1f)
        {
            velocity = new Vector3();
            //Vector3 posDifference = transform.position - new Vector3(transform.position.x, 1, transform.position) 
        } else
        {
            velocity += new Vector3(0, -1, 0);
            
        }

        transform.position += velocity * Time.deltaTime;

    }
}