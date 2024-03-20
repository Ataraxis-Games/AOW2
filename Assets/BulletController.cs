using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [HideInInspector]
    public float damage;
    [HideInInspector]
    public int team;

    private void OnTriggerEnter(Collider other)
    {
        if(team == 1 && other.tag == "team2")
        {
            other.GetComponent<UnitController>().Hurt(GetComponent<Rigidbody>().velocity, GetComponent<Rigidbody>().velocity.sqrMagnitude / 5000, damage, 1f);
        }
        else if(team == 2 && other.tag == "team1")
        {
            other.GetComponent<UnitController>().Hurt(GetComponent<Rigidbody>().velocity, GetComponent<Rigidbody>().velocity.sqrMagnitude / 5000, damage, 1f);
        }
        else if(team == 1 && other.tag == "team1")
        {
            return;
        }
        else if(team == 2 && other.tag == "team2")
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }        
    }
}
