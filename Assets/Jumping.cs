using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour {

    Vector3 velocity = new Vector3();
    private int jumpHeight = 30;
    private bool canJump = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") && canJump == true) {
            velocity += jumpHeight * new Vector3(0, 1, 0);
            canJump = false;
        }

        transform.position += velocity * Time.deltaTime;
        velocity *= .8f;
        if (transform.position.y <= 1.01) canJump = true;
    }
}
