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

	// Use this for initialization
	void Start () {
        CollidingManager.powerUps.Add(GetComponent<AABBCollider>());
        print(powerUpType);
    }
	
	// Update is called once per frame
	void OnDestroy () {
        CollidingManager.powerUps.Remove(GetComponent<AABBCollider>());
    }
}
