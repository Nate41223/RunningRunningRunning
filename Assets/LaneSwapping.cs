using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSwapping : MonoBehaviour {

    public int lane = 2;
    public int previousLane = 2;
    private int laneMin = 0;
    private int laneMax = 4;

    public int column = 1;
    public int previousColumn = 1;
    private int columnMin = 0;
    private int columnMax = 2;

    private Vector3 laneSwap = new Vector3(1, 0, 0);
    private Vector3 columnSwap = new Vector3(0, 1, 0);

    private int Speed = 15;
    private bool canSwap = true;

    // Lanes
    private Vector3 leftOuterLane = new Vector3(0, 2, 0); // List Index Number: 0
    private Vector3 leftLane = new Vector3(2, 2, 0); // List Index Number: 1
    private Vector3 middleLane = new Vector3(4, 2, 0); // List Index Number: 2
    private Vector3 rightLane = new Vector3(6, 2, 0); // List Index Number: 3
    private Vector3 rightOuterLane = new Vector3(8, 2, 0); // List Index Number: 4

    // Columns
    private Vector3 bottomColumn = new Vector3(4, 0, 0); // List Index Number: 0
    private Vector3 middleColumn = new Vector3(4, 2, 0); // List Index Number: 1
    private Vector3 topColumn = new Vector3(4, 4, 0); // List Index Number: 2

    List<Vector3> Lanes = new List<Vector3>();
    List<Vector3> Columns = new List<Vector3>();

    // Use this for initialization
    void Start () {
        Lanes.Add(leftOuterLane);
        Lanes.Add(leftLane);
        Lanes.Add(middleLane);
        Lanes.Add(rightLane);
        Lanes.Add(rightOuterLane);

        Columns.Add(bottomColumn);
        Columns.Add(middleColumn);
        Columns.Add(topColumn);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Horizontal") < 0)
        {
            if (canSwap == true)
            {
                if(lane > laneMin)
                {
                    lane--;
                    canSwap = false;
                }    
            }
        } else if (Input.GetAxis("Horizontal") > 0)
        {
            if (canSwap == true)
            {
                if(lane < laneMax)
                {
                    lane++;
                    canSwap = false;
                }   
            }
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            if (canSwap == true)
            {
                if (column > columnMin)
                {
                    column--;
                    canSwap = false;
                }
            }
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            if (canSwap == true)
            {
                if (column < columnMax)
                {
                    column++;
                    canSwap = false;
                }
            }
        }

        updateLaneColumnPosition();

        //leftLane.y = transform.position.y;
        //middleLane.y = transform.position.y;
        //rightLane.y = transform.position.y;

        if (lane != previousLane || column != previousColumn)
        {
            moveTowardLane();
            moveTowardColumn();
            checkLaneAlignment();
            checkColumnAlignment();
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

    void updateLaneColumnPosition()
    {
        Lanes[0] = new Vector3(0, 0 + 2 * column, 0); // List Index Number: 0
        Lanes[1] = new Vector3(2, 0 + 2 * column, 0); // List Index Number: 1
        Lanes[2] = new Vector3(4, 0 + 2 * column, 0); // List Index Number: 2
        Lanes[3] = new Vector3(6, 0 + 2 * column, 0); // List Index Number: 3
        Lanes[4] = new Vector3(8, 0 + 2 * column, 0); // List Index Number: 4

        Columns[0] = new Vector3(0 + 2 * lane, 0, 0); // List Index Number: 0
        Columns[1] = new Vector3(0 + 2 * lane, 2, 0); // List Index Number: 1
        Columns[2] = new Vector3(0 + 2 * lane, 4, 0); // List Index Number: 2
    }

    void moveTowardLane()
    {
        if (lane > previousLane) transform.position += Speed * laneSwap * Time.deltaTime;
        if (lane < previousLane) transform.position -= Speed * laneSwap * Time.deltaTime;
    }
    void moveTowardColumn()
    {
        if (column > previousColumn) transform.position += Speed * columnSwap * Time.deltaTime;
        if (column < previousColumn) transform.position -= Speed * columnSwap * Time.deltaTime;
    }

    void checkColumnAlignment()
    {
        if (column == 0 && transform.position.y < Columns[column].y)
        {
            transform.position = Columns[column];
            canSwap = true;
            previousColumn = column;
        }
        else if (column == 1 && previousColumn == 2 && transform.position.y < Columns[column].y)
        {
            transform.position = Columns[column];
            canSwap = true;
            previousColumn = column;
        }
        else if (column == 1 && previousColumn == 0 && transform.position.y > Columns[column].y)
        {
            transform.position = Columns[column];
            canSwap = true;
            previousColumn = column;
        }
        else if (column == 2 && transform.position.y > Columns[column].y)
        {
            transform.position = Columns[column];
            canSwap = true;
            previousColumn = column;
        }
    }

    void checkLaneAlignment()
    {
        if (lane == 0 && transform.position.x < Lanes[lane].x)
        {
            transform.position = Lanes[lane];
            canSwap = true;
            previousLane = lane;
        }
        else if (lane == 1 && previousLane == 2 && transform.position.x < Lanes[lane].x)
        {
            transform.position = Lanes[lane];
            canSwap = true;
            previousLane = lane;
        }
        else if (lane == 1 && previousLane == 0 && transform.position.x > Lanes[lane].x)
        {
            transform.position = Lanes[lane];
            canSwap = true;
            previousLane = lane;
        }
        else if (lane == 2 && previousLane == 3 && transform.position.x < Lanes[lane].x)
        {
            transform.position = Lanes[lane];
            canSwap = true;
            previousLane = lane;
        }
        else if (lane == 2 && previousLane == 1 && transform.position.x > Lanes[lane].x)
        {
            transform.position = Lanes[lane];
            canSwap = true;
            previousLane = lane;
        }
        else if (lane == 3 && previousLane == 4 && transform.position.x < Lanes[lane].x)
        {
            transform.position = Lanes[lane];
            canSwap = true;
            previousLane = lane;
        }
        else if (lane == 3 && previousLane == 2 && transform.position.x > Lanes[lane].x)
        {
            transform.position = Lanes[lane];
            canSwap = true;
            previousLane = lane;
        }
        else if (lane == 4 && transform.position.x > Lanes[lane].x)
        {
            transform.position = Lanes[lane];
            canSwap = true;
            previousLane = lane;
        }
    }
}
