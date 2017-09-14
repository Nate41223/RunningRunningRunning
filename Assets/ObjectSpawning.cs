using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour {

    public GameObject LeftBackSpawnPoint;
    public GameObject LeftFrontSpawnPoint;
    public GameObject MiddleBackSpawnPoint;
    public GameObject MiddleFrontSpawnPoint;
    public GameObject RightBackSpawnPoint;
    public GameObject RightFrontSpawnPoint;

    public GameObject Wall;

    List<GameObject> Points = new List<GameObject>();

    // Use this for initialization
    public void spawnObjects () {

        Points.Add(LeftBackSpawnPoint);
        Points.Add(LeftFrontSpawnPoint);
        Points.Add(MiddleBackSpawnPoint);
        Points.Add(MiddleFrontSpawnPoint);
        Points.Add(RightBackSpawnPoint);
        Points.Add(RightFrontSpawnPoint);

        print(Points.Count);

        // gets the amount of objects it wants to spawn for that chunk
        int amount = Random.Range(0, 7); // max is exclusive

        while (amount > 0)
        {
            int spawnLocation = Random.Range(0, Points.Count);
            Vector3 position = Points[spawnLocation].transform.position;
            var newWall = Instantiate(Wall, position, Quaternion.identity);
            newWall.transform.parent = transform;
            Points.RemoveAt(spawnLocation);
            amount--;
            
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
