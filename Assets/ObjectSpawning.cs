using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour {

    // Spawn Areas
        // Lane One
    public GameObject topLaneOneSpawnPoint;  // List Index Number: 0
    public GameObject middleLaneOneSpawnPoint; // List Index Number: 1
    public GameObject bottomLaneOneSpawnPoint; // List Index Number: 2
        // Lane Two
    public GameObject topLaneTwoSpawnPoint; // List Index Number: 3
    public GameObject middleLaneTwoSpawnPoint; // List Index Number: 4
    public GameObject bottomLaneTwoSpawnPoint; // List Index Number: 5
        // Lane Three
    public GameObject topLaneThreeSpawnPoint; // List Index Number: 6
    public GameObject middleLaneThreeSpawnPoint; // List Index Number: 7
    public GameObject bottomLaneThreeSpawnPoint; // List Index Number: 8
        // Lane Four
    public GameObject topLaneFourSpawnPoint; // List Index Number: 9
    public GameObject middleLaneFourSpawnPoint; // List Index Number: 10
    public GameObject bottomLaneFourSpawnPoint; // List Index Number: 11
        // Lane Five
    public GameObject topLaneFiveSpawnPoint; // List Index Number: 12
    public GameObject middleLaneFiveSpawnPoint; // List Index Number: 13
    public GameObject bottomLaneFiveSpawnPoint; // List Index Number: 14

    // Obstacles
    public GameObject Wall; // List Index Number: 0
    public GameObject PointsPowerUp; // List Index Number: 1
    public GameObject BreakPowerUp; // List Index Number: 2
    public GameObject SlowPowerUp; // List Index Number: 3
    public GameObject AttractPowerUp; // List Index Number: 4


    List<GameObject> Points = new List<GameObject>();
    List<GameObject> Obstacles = new List<GameObject>();

    // gets the amount of objects it wants to spawn for that chunk

    

    // Use this for initialization
    public void spawnObjects () {

        // Adds all Spawn Areas to the Points List
            // Lane One
        Points.Add(topLaneOneSpawnPoint);
        Points.Add(middleLaneOneSpawnPoint);
        Points.Add(bottomLaneOneSpawnPoint);
            // Lane Two
        Points.Add(topLaneTwoSpawnPoint);
        Points.Add(middleLaneTwoSpawnPoint);
        Points.Add(bottomLaneTwoSpawnPoint);
            // Lane Three
        Points.Add(topLaneThreeSpawnPoint);
        Points.Add(middleLaneThreeSpawnPoint);
        Points.Add(bottomLaneThreeSpawnPoint);
            // Lane Four
        Points.Add(topLaneFourSpawnPoint);
        Points.Add(middleLaneFourSpawnPoint);
        Points.Add(bottomLaneFourSpawnPoint);
            // Lane Five
        Points.Add(topLaneFiveSpawnPoint);
        Points.Add(middleLaneFiveSpawnPoint);
        Points.Add(bottomLaneFiveSpawnPoint);

        // Adds all Objects to the Obstacles List
        Obstacles.Add(Wall);
        Obstacles.Add(PointsPowerUp);
        Obstacles.Add(BreakPowerUp);
        Obstacles.Add(SlowPowerUp);
        Obstacles.Add(AttractPowerUp);

        int amount = Random.Range(4, Points.Count); // max is exclusive
        int amountOfPowerUp = Random.Range(0, 3);

        while (amount > 0)
        {
            // determines the spawn location of the object
            int spawnLocation = Random.Range(0, Points.Count); // max is exclusive
            Vector3 position = Points[spawnLocation].transform.position;

            // determines if a powerup object can replace a wall object in this position
            int isPowerUp = Random.Range(0, 101); // max is exclusive

            // if isPowerUp is less than 25 AND we havnt spawned a powerup on this trackpiece yet, then spawn a powerup in this location
            // OR if this is the last object spawning on this track piece AND we havnt spawned a powerup on this trackpiece yet, then spawn a powerup in this location
            // ELSE spawn a wall in this location
            if (isPowerUp < 25 && amountOfPowerUp != 0 || amount <= amountOfPowerUp && amountOfPowerUp != 0)
            {
                int powerUp = Random.Range(1, Obstacles.Count);
                var newPowerUp = Instantiate(getPowerUp(powerUp), position, Quaternion.identity);
                newPowerUp.transform.parent = transform;
                newPowerUp.GetComponent<PowerUp>().powerUpType = powerUp;
                amountOfPowerUp--;
            } else
            {
                var newWall = Instantiate(Wall, position, Quaternion.identity);
                newWall.transform.parent = transform;
            }

            // remove this point from the List of points so that only one object can spawn in that location
            Points.RemoveAt(spawnLocation);
            amount--;
            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject getPowerUp(int powerUpIndexNumber)
    {
        return Obstacles[powerUpIndexNumber]; // max is exclusive
    }
}
