using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSwapping : MonoBehaviour {

    public int lane = 2;
    public int previousLane = 2;
    private int laneMin = 1;
    private int laneMax = 3;
    private Vector3 laneSwap = new Vector3(1, 0, 0);
    private int Speed = 10;
    private bool canSwapLane = true;

    public Vector3 leftLane = new Vector3(-2, 1, -6);
    public Vector3 middleLane = new Vector3(0, 1, -6);
    public Vector3 rightLane = new Vector3(2, 1, -6);


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (canSwapLane == true)
            {
                if(lane > laneMin)
                {
                    lane--;
                    canSwapLane = false;
                }    
            }
        } else if (Input.GetAxis("Horizontal") > 0)
        {
            if (canSwapLane == true)
            {
                if(lane < laneMax)
                {
                    lane++;
                    canSwapLane = false;
                }   
            }
        }

        leftLane.y = transform.position.y;
        middleLane.y = transform.position.y;
        rightLane.y = transform.position.y;

        if (lane != previousLane)
        {
            moveTowardLane();
            checkLaneAlignment();
        }

        /**
        if (lane == 1)
        {
            transform.position = new Vector3(-2, 1, -6);
        } else if (lane == 2)
        {
            transform.position = new Vector3(0, 1, -6);
        } else if (lane == 3)
        {
            transform.position = new Vector3(2, 1, -6);
        }
        **/
    }

    void moveTowardLane()
    {
        if (lane > previousLane) transform.position += Speed * laneSwap * Time.deltaTime;
        if (lane < previousLane) transform.position -= Speed * laneSwap * Time.deltaTime;
    }

    void checkLaneAlignment()
    {
        if (lane == 1 && transform.position.x <= leftLane.x)
        {
            transform.position = leftLane;
            canSwapLane = true;
            previousLane = lane;
        }
        else if (lane == 2 && previousLane == 3 && transform.position.x <= middleLane.x)
        {
            transform.position = middleLane;
            canSwapLane = true;
            previousLane = lane;
        }
        else if (lane == 2 && previousLane == 1 && transform.position.x >= middleLane.x)
        {
            transform.position = middleLane;
            canSwapLane = true;
            previousLane = lane;
        }
        else if (lane == 3 && transform.position.x >= rightLane.x)
        {
            transform.position = rightLane;
            canSwapLane = true;
            previousLane = lane;
        }
    }
}
