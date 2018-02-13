using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawning : MonoBehaviour {

    public GameObject TrackChunk;
    public Transform Player;

    public List<GameObject> chunks = new List<GameObject>();
	
	// Updates the track pieces
	void Update ()
    {
        CheckPlayerDistance();
    }

    private void CheckPlayerDistance()
    {
        // determines if the oldest track piece is past the player
        if (chunks.Count > 0)
        {
            if (Player.position.z - chunks[0].transform.position.z > 23)
            {
                Destroy(chunks[0]);
                chunks.RemoveAt(0);
            }
        }

        // if it is, destroy it and spawn another piece
        while (chunks.Count < 4)
        {
            // spawn track piece
            spawnTrack();
        }
    }

    private void spawnTrack()
    {
        // holds a position for where the track should spawn
        Vector3 position = new Vector3 (4, -2, -25);

        // if this is not the first track piece, find the connecting spot
        if (chunks.Count > 0)
        {
            position = chunks[chunks.Count - 1].transform.Find("Connector").position;
        }

        // spawn track piece
        GameObject obj = Instantiate(TrackChunk, position, Quaternion.identity);
        // add the piece to the array
        chunks.Add(obj);

        // spawn walls and power ups if there are more than three track pieces
        if (chunks.Count > 3)
        {
            obj.GetComponent<ObjectSpawning>().SpawnObjects();
        }
    }
}
