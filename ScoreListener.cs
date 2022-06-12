using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.CoreGameKit;
using UnityEngine;

public class ScoreListener : MonoBehaviour
{

    //Current variables

    public int currentLevel;
    public int currentScore;

    //Level Limits

    public int level2LimitDefault;
    public int level3LimitDefault;
    public int level4LimitDefault;
    public int level5LimitDefault;
    public int level6LimitDefault;
    public int level7LimitDefault;
    public int level8LimitDefault;
    public int level9LimitDefault;
    public int level10LimitDefault;
    public int level11LimitDefault;
    public int level12LimitDefault;
    public int level13LimitDefault;
    public int level14LimitDefault;
    public int level15LimitDefault;

    public int level2Limit;
    public int level3Limit;
    public int level4Limit;
    public int level5Limit;
    public int level6Limit;
    public int level7Limit;
    public int level8Limit;
    public int level9Limit;
    public int level10Limit;
    public int level11Limit;
    public int level12Limit;
    public int level13Limit;
    public int level14Limit;
    public int level15Limit;

    public static int limitAdd;

    Vector3 spawnPosition = new Vector3(0.0f, 0.0f, 0.0f);

    void Start()
    {

        //reset level sent bools
        //reset default level limits
        //reset boss destroyed bools
        //find boss spawners
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BossDestroyed()

    {
        currentLevel = GlobalsManager.level;
        currentScore = GlobalsManager.score;

        //Not using switch statement because constant values must be entered

        if (currentScore >= level2Limit && currentLevel == 1)

        {
            GlobalsManager.level += 1;
        }

        if (currentScore >= level3Limit && currentLevel == 2)

        {
            if (GlobalsManager.bossPresent)

            {
                Debug.Log("Waiting for Pirate Boss to be Destroyed");
            }

            else

            {
                if (GlobalsManager.pirateBossDestroyed)

                {
                    GlobalsManager.level += 1;
                }

                else

                {
                    GlobalsManager.pirateBossDestroyed = false;
                    GlobalsManager.bossPresent = true;
                    DarkTonic.CoreGameKit.PoolBoss.Spawn(GlobalsManager.pirateBoss, spawnPosition, GlobalsManager.pirateBoss.rotation, null);
                }

            }
        }

        if (currentScore >= level4Limit && currentLevel == 3)
        {

        }

        if (currentScore >= level5Limit && currentLevel == 4)
        {

        }

        if (currentScore >= level6Limit && currentLevel == 5)
        {

        }

        if (currentScore >= level7Limit && currentLevel == 6)
        {

        }

        if (currentScore >= level8Limit && currentLevel == 7)
        {

        }

        if (currentScore >= level9Limit && currentLevel == 8)
        {

        }

        if (currentScore >= level10Limit && currentLevel == 9)
        {

        }

        if (currentScore >= level11Limit && currentLevel == 10)
        {

        }

        if (currentScore >= level12Limit && currentLevel == 11)
        {

        }

        if (currentScore >= level13Limit && currentLevel == 12)
        {

        }

        if (currentScore >= level14Limit && currentLevel == 13)
        {

        }

        if (currentScore >= level15Limit && currentLevel == 14)
        {

        }
        else return;
    }
}