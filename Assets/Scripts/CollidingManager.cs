using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingManager : MonoBehaviour {

    public AudioClip wallDestroySound;
    public AudioClip powerUpSound;

    public AABBCollider player;

    // holds AABBColiders for walls and powerups so that they can be checked against the player
    static public List<AABBCollider> walls = new List<AABBCollider>();
    static public List<AABBCollider> powerUps = new List<AABBCollider>();
	
	// Checks for collision every frame after every other update function
	void LateUpdate () {
        DoCollisionDetection();
	}

    // loop through every wall and powerup and check their collision against the player
    // if they are colliding, destroy the wall
    private void DoCollisionDetection()
    {
        for (int i = walls.Count - 1; i >= 0; i--)
        {
            // if the wall is colliding
            if(walls[i].CheckOverlap(player))
            {
                Destroy(walls[i].gameObject); // destroy the colliding wall
                AudioSource.PlayClipAtPoint(wallDestroySound, transform.position); // play wall destroying sound

                // if the player is invincible, then add 50 points to score
                // if not, then the player loses a life
                if (GamePlayManager.isInvincible == true)
                {
                    GamePlayManager.points += 50;
                } else
                {
                    GamePlayManager.playerLives--;
                }
            }

        }

        for (int i = powerUps.Count - 1; i >= 0; i--)
        {
            // if the powerup is colliding
            if (powerUps[i].CheckOverlap(player))
            {
                powerUps[i].gameObject.GetComponent<PowerUp>().applyPowerUpChanges(); // apply changes based on power up type
                Destroy(powerUps[i].gameObject); // destroy the colliding powerup
                AudioSource.PlayClipAtPoint(powerUpSound, transform.position); // play power up sound
            }

        }
    }
}
