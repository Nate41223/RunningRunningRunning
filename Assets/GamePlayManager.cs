using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager {

    public static float points = 0; // List Index Number: 1
    public static float nextPointsThreshold = 1000;
    public static int breakPowerUps = 0; // List Index Number: 2
    public static int slowPowerUps = 0; // List Index Number: 3
    public static int attractPowerUps = 0; // List Index Number: 4

    public static int playerLives = 3;
    public static int level = 1;

    public static int speed = 12;
    public static int baseSpeed = 12;

    public static Vector3 playerPosition;
    public static bool isAttractive = false;
    public static bool isInvincible = false;

    public static void UpdateGame()
    {
        checkForLevelAdvancement();

        if (playerLives <= 0)
        {
            onPlayerDeath();
        }
    }

    

    public static void onPlayerDeath()
    {
        SceneManager.LoadScene("GameOverScene");
        // switch to game over screen
        // death sound
    }

    public static void resetGame()
    {
    points = 0; // List Index Number: 1
    nextPointsThreshold = 1000;
    breakPowerUps = 0; // List Index Number: 2
    slowPowerUps = 0; // List Index Number: 3
    attractPowerUps = 0; // List Index Number: 4

    playerLives = 3;
    level = 1;

    speed = 12;
    baseSpeed = 12;

    isAttractive = false;
    isInvincible = false;
    }

    private static void checkForLevelAdvancement()
    {
        if (points >= nextPointsThreshold)
        {
            nextPointsThreshold += 1000;
            playerLives += 2;
            level++;

            int powerUpsLevelAmount = breakPowerUps + slowPowerUps + attractPowerUps;
            points += powerUpsLevelAmount * 50;
            breakPowerUps = 0;
            slowPowerUps = 0;
            attractPowerUps = 0;

            if (baseSpeed == speed)
            {
                baseSpeed += 2;
                speed += 2;
            }
            else
            {
                baseSpeed += 2;
            }

            for (int i = CollidingManager.walls.Count - 1; i >= 0; i--)
            {
                CollidingManager.Destroy(CollidingManager.walls[i].gameObject);
            }

            for (int i = CollidingManager.powerUps.Count - 1; i >= 0; i--)
            {
                CollidingManager.Destroy(CollidingManager.powerUps[i].gameObject);
            }


        }
    }
}
