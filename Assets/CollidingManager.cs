using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingManager : MonoBehaviour {

    public AudioClip wallDestroySound;
    public AudioClip powerUpSound;

    public AABBCollider player;
    static public List<AABBCollider> walls = new List<AABBCollider>();
    static public List<AABBCollider> powerUps = new List<AABBCollider>();


    // Use this for initialization
    void Start () {
		
	}
	
	// Checks for collision every frame after every other update function
	void LateUpdate () {
        DoCollisionDetection();
	}

    // loop through every wall and check their collision against the player
    // if they are colliding, destroy the wall
    private void DoCollisionDetection()
    {
        for (int i = walls.Count - 1; i >= 0; i--)
        {
            if(walls[i].CheckOverlap(player))
            {
                Destroy(walls[i].gameObject);
                AudioSource.PlayClipAtPoint(wallDestroySound, transform.position);
            }

        }

        for (int i = powerUps.Count - 1; i >= 0; i--)
        {
            if (powerUps[i].CheckOverlap(player))
            {
                Destroy(powerUps[i].gameObject);
                AudioSource.PlayClipAtPoint(powerUpSound, transform.position);
            }

        }
    }
}
