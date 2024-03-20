using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "AOW/Create Weapon")]
public class Weapon : ScriptableObject
{
    public string name;
    public int ammo;
    public GameObject bullet;
    public float muzzleVelocity;
    public float damage;
    public float range;
}
