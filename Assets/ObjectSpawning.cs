using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour {

    // Spawn Areas
    public GameObject LeftBackSpawnPoint;  // List Index Number: 0
    public GameObject LeftFrontSpawnPoint; // List Index Number: 1
    public GameObject MiddleBackSpawnPoint; // List Index Number: 2
    public GameObject MiddleFrontSpawnPoint; // List Index Number: 3
    public GameObject RightBackSpawnPoint; // List Index Number: 4
    public GameObject RightFrontSpawnPoint; // List Index Number: 5

    // Obstacles
    public GameObject Wall; // List Index Number: 0
    public GameObject PointsPowerUp; // List Index Number: 1
    public GameObject BreakPowerUp; // List Index Number: 2
    public GameObject SlowPowerUp; // List Index Number: 3
    public GameObject AttractPowerUp; // List Index Number: 4


    List<GameObject> Points = new List<GameObject>();
    List<GameObject> Obstacles = new List<GameObject>();

    // Use this for initialization
    public void spawnObjects () {

        // Adds all Spawn Areas to the Points List
        Points.Add(LeftBackSpawnPoint);
        Points.Add(LeftFrontSpawnPoint);
        Points.Add(MiddleBackSpawnPoint);
        Points.Add(MiddleFrontSpawnPoint);
        Points.Add(RightBackSpawnPoint);
        Points.Add(RightFrontSpawnPoint);

        // Adds all Objects to the Obstacles List
        Obstacles.Add(Wall);
        Obstacles.Add(PointsPowerUp);
        Obstacles.Add(BreakPowerUp);
        Obstacles.Add(SlowPowerUp);
        Obstacles.Add(AttractPowerUp);

        // gets the amount of objects it wants to spawn for that chunk
        int amount = Random.Range(1, Points.Count + 1); // max is exclusive
        int amountOfPowerUp = 1;

        print(amount);

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
            if (isPowerUp < 25 && amountOfPowerUp != 0 || amount != 1 && amountOfPowerUp != 0)
            {
                var newPowerUp = Instantiate(determinePowerUp(), position, Quaternion.identity);
                newPowerUp.transform.parent = transform;
                amountOfPowerUp = 0;
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

    public GameObject determinePowerUp()
    {
        return Obstacles[Random.Range(1, Obstacles.Count)]; // max is exclusive
    }
}
