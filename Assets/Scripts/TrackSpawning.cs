﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawning : MonoBehaviour {

    public GameObject TrackChunk;
    public Transform Player;

    public List<GameObject> chunks = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(chunks.Count > 0)
        {
            if (Player.position.z - chunks[0].transform.position.z > 23)
            {
                Destroy(chunks[0]);
                chunks.RemoveAt(0);
            }
        }
		
        while (chunks.Count < 4)
        {
            spawnTrack();
        }
    }

    private void spawnTrack()
    {
        Vector3 position = new Vector3 (4, -2, -25);

        if (chunks.Count > 0)
        {
            position = chunks[chunks.Count - 1].transform.Find("Connector").position;
        }

        GameObject obj = Instantiate(TrackChunk, position, Quaternion.identity);
        chunks.Add(obj);

        if (chunks.Count > 3)
        {
            obj.GetComponent<ObjectSpawning>().spawnObjects();
        }
    }
}