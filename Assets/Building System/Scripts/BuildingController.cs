using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BuildingController : MonoBehaviour
{
    public GameManager gameManager;
    public int team;
    [HideInInspector]
    public float currentHealth;
    public Building buildingType;
    [HideInInspector]
    public bool enabled = false;
    [HideInInspector]
    public BuildingManager manager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        manager = FindObjectOfType<BuildingManager>();
        team = PhotonNetwork.LocalPlayer.ActorNumber;
        currentHealth = buildingType.health;
    }

    void Update()
    {
        team = PhotonNetwork.LocalPlayer.ActorNumber;
        if (enabled)
        {
            buildingStuff();
        }
    }

    public virtual void buildingStuff()
    {
        return;
    }

    public void dealDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
