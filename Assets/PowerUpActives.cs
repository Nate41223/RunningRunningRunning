using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActives : MonoBehaviour {

    private bool isPowerUpActive = false;
    private int powerUpType = 0;

    private float buffTimer;

    public Material playerColor;
    public Material slowPower;
    public Material breakPower;
    public Material attractPower;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) // Slow PowerUp  Type: 1
        {
            if (isPowerUpActive == false && GamePlayManager.slowPowerUps > 0)
            {
                GetComponent<MeshRenderer>().material = slowPower;
                GamePlayManager.speed = GamePlayManager.speed/2;
                powerUpType = 1;
                isPowerUpActive = true;
                buffTimer = 2f;
                GamePlayManager.slowPowerUps--;
                GamePlayManager.points += 50;
                
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) // Break PowerUp  Type: 2
        {
            if (isPowerUpActive == false && GamePlayManager.breakPowerUps > 0)
            {
                GetComponent<MeshRenderer>().material = breakPower;
                GamePlayManager.speed = GamePlayManager.speed * 2;
                powerUpType = 2;
                isPowerUpActive = true;
                buffTimer = 2f;
                GamePlayManager.isInvincible = true;
                GamePlayManager.breakPowerUps--;
                GamePlayManager.points += 50;
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) // Attract PowerUp  Type: 3
        {
            if (isPowerUpActive == false && GamePlayManager.attractPowerUps > 0)
            {
                GetComponent<MeshRenderer>().material = attractPower;
                powerUpType = 3;
                isPowerUpActive = true;
                buffTimer = 2f;
                GamePlayManager.isAttractive = true;
                GamePlayManager.attractPowerUps--;
                GamePlayManager.points += 50;
            }
        }

        if(isPowerUpActive == true)
        {
            if (buffTimer > 0)
            {
                buffTimer -= Time.deltaTime;
            } else
            {
                switch (powerUpType)
                {
                    case 1:
                        GetComponent<MeshRenderer>().material = playerColor;
                        GamePlayManager.speed = GamePlayManager.baseSpeed;
                        break;
                    case 2:
                        GetComponent<MeshRenderer>().material = playerColor;
                        GamePlayManager.speed = GamePlayManager.baseSpeed;
                        GamePlayManager.isInvincible = false;
                        break;
                    case 3:
                        GetComponent<MeshRenderer>().material = playerColor;
                        GamePlayManager.isAttractive = false;
                        break;
                }
                powerUpType = 0;
                isPowerUpActive = false;
            }
        }
    }
}
