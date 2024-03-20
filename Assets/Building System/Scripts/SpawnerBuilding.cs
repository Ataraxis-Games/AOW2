using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnerBuilding : BuildingController
{
    public GameObject objToSpawn;
    public float spawnOffset;
    public float timeToSpawn;
    float timer;
    public float energyCost = 10;

    void Awake()
    {
        timer = timeToSpawn;
    }

    public override void buildingStuff()
    {
        if (enabled && GetComponent<PhotonView>().IsMine)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                GameObject spawnedObj = PhotonNetwork.Instantiate(objToSpawn.name, transform.position + (spawnOffset * Random.Range(0.1f, 0.5f) * transform.up), Quaternion.Euler(Vector3.zero));
                spawnedObj.GetComponent<UnitController>().team = team;
                timer = timeToSpawn;
                manager.money -= energyCost;
            }
        }
    }
}
