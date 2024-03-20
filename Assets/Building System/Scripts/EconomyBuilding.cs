using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyBuilding : BuildingController
{
    public float moneyToAdd;
    public float timeToSpawn;
    float timer;

    void Awake()
    {
        timer = timeToSpawn;
    }

    public override void buildingStuff()
    {
        if (enabled)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                manager.money += moneyToAdd;
                timer = timeToSpawn;
            }
        }
    }
}
