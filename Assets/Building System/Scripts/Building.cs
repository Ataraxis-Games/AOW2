using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "AOW")]
public class Building : ScriptableObject
{
    public GameObject obj;
    public float health;
    public float cost;
}
