using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    /** Obstacles (Reference)
    public GameObject Wall;  List Index Number: 0
    public GameObject PointsPowerUp;  List Index Number: 1
    public GameObject BreakPowerUp;  List Index Number: 2
    public GameObject SlowPowerUp;  List Index Number: 3
    public GameObject AttractPowerUp;  List Index Number: 4
    **/

    public int powerUpType;

    private bool moveTowardsPlayer = false;

	// Use this for initialization
	void Start () {
        CollidingManager.powerUps.Add(GetComponent<AABBCollider>());
    }

    void LateUpdate() 
    {
        if (GamePlayManager.isAttractive == true)
        {
            float distanceX = Mathf.Abs(GamePlayManager.playerPosition.x - transform.position.x);
            float distanceY = Mathf.Abs(GamePlayManager.playerPosition.y - transform.position.y);
            float distanceZ = Mathf.Abs(GamePlayManager.playerPosition.z - transform.position.z);

            float distanceXZ = Mathf.Sqrt((distanceX * distanceX) + (distanceZ * distanceZ));
            float distanceXYZ = Mathf.Sqrt((distanceY * distanceY) + (distanceXZ * distanceXZ));

            if (distanceXYZ <= 5)
            {
                moveTowardsPlayer = true; 
            }
        }

        if (moveTowardsPlayer == true)
        {
            transform.position += (GamePlayManager.playerPosition - transform.position) * Time.deltaTime * (GamePlayManager.speed + 2);
        }
    }

    // Update is called once per frame
    void OnDestroy () {
        CollidingManager.powerUps.Remove(GetComponent<AABBCollider>());
    }

    public void applyPowerUpChanges()
    {
        switch (powerUpType)
        {
            case 1:
                GamePlayManager.points += 100;
                break;
            case 2:
                if (GamePlayManager.breakPowerUps < 5)
                {
                    GamePlayManager.breakPowerUps++;
                    GamePlayManager.points += 50;
                } else GamePlayManager.points += 100;
                break;
            case 3:
                if (GamePlayManager.slowPowerUps < 5)
                {
                    GamePlayManager.slowPowerUps++;
                    GamePlayManager.points += 50;
                } else GamePlayManager.points += 100;
                break;
            case 4:
                if (GamePlayManager.attractPowerUps < 5) 
                {
                    GamePlayManager.attractPowerUps++;
                    GamePlayManager.points += 50;
                } else GamePlayManager.points += 100;
                break;
        }
    }
}
