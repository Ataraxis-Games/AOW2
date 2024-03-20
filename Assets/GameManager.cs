using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static WestTools;
using Photon.Pun;

public class GameManager : MonoBehaviourPun
{
    public List<Transform> team1 = new List<Transform>();
    public List<Transform> team2 = new List<Transform>();

    List<Transform> selectedUnits = new List<Transform>();

    [SerializeField]
    LayerMask allLayer;

    private void Update()
    {
        foreach(Transform t in selectedUnits)
        {
            t.GetComponent<UnitController>().timer = 0.1f;
        }
    }

    public void isClosestEnemyInRange(Transform curUnit, float range, int team)
    {
        if (team == 1)
        {
            RaycastHit hit;
            bool thing = Physics.Raycast(curUnit.transform.position, (GetClosest(team2.ToArray(), curUnit).position - curUnit.position).normalized, out hit, range, allLayer);
            if (thing == true)
            {
                if (hit.transform.tag == "team2")
                {
                    curUnit.GetComponent<UnitController>().canShoot = true;
                }
                else
                {
                    curUnit.GetComponent<UnitController>().canShoot = false;
                }
            }
        }
        if(team == 2)
        {
            RaycastHit hit;
            bool thing = Physics.Raycast(curUnit.transform.position, (GetClosest(team1.ToArray(), curUnit).position - curUnit.position).normalized, out hit, range, allLayer);
            if(thing == true)
            {
                if(hit.transform.tag == "team1")
                {
                    curUnit.GetComponent<UnitController>().canShoot = true;
                }
                else
                {
                    curUnit.GetComponent<UnitController>().canShoot = false;
                }
            }
        }
    }

    public Transform getClosestEnemy(Transform curUnit, int team)
    {
        if(team == 1)
        {
            return GetClosest(team2.ToArray(), curUnit);
        }
        else if(team == 2)
        {
            return GetClosest(team1.ToArray(), curUnit);
        }
        else
        {
            return null;
        }
    }

    public void selectUnits(Vector3 startPos, Vector3 endPos, int team)
    {
        selectedUnits.Clear();
        // Im gonna define my box!
        if(team == 1)
        {
            for (int i = 0; i < team1.Count; i++)
            {
                if (IsPointInsideRectangle(team1[i].position, startPos, endPos))
                {
                    selectedUnits.Add(team1[i]);
                }
            }
        }
        else if(team == 2)
        {
            for (int i = 0; i < team2.Count; i++)
            {
                if (IsPointInsideRectangle(team2[i].position, startPos, endPos))
                {
                    selectedUnits.Add(team2[i]);
                }
            }
        }

        foreach(Transform t in selectedUnits)
        {
            t.GetComponent<UnitController>().timer = 0.1f;
        }
    }

    bool IsPointInsideRectangle(Vector3 point, Vector3 rectPoint1, Vector3 rectPoint2)
    {
        float minX = Mathf.Min(rectPoint1.x, rectPoint2.x);
        float maxX = Mathf.Max(rectPoint1.x, rectPoint2.x);
        float minY = Mathf.Min(rectPoint1.z, rectPoint2.z);
        float maxY = Mathf.Max(rectPoint1.z, rectPoint2.z);

        return point.x >= minX && point.x <= maxX && point.z >= minY && point.z <= maxY;
    }

    public void setUnitTargets(Vector3 pos)
    {
        foreach(Transform t in selectedUnits)
        {
            photonView.RPC("MoveUnit", RpcTarget.All, pos, t.position, t.GetComponent<UnitController>().team);
        }
    }

    [PunRPC]
    void MoveUnit(Vector3 pos, Vector3 currentPos, int team)
    {
        if (team == 1)
        {
            foreach(Transform t in team1)
            {
                if(t.position == currentPos)
                {
                    t.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
                    t.GetComponent<UnitController>().target = pos;
                    t.GetComponent<UnitController>().SetTarget();
                }
            }
        }
        else if (team == 2)
        {
            foreach (Transform t in team2)
            {
                if (t.position == currentPos)
                {
                    t.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
                    t.GetComponent<UnitController>().target = pos;
                    t.GetComponent<UnitController>().SetTarget();
                }
            }
        }
    }

    public void DestroyUnit(Transform unit, int team)
    {
        if(team == 1)
        {
            for(int i = 0; i < team1.Count; i++)
            {
                if (unit == team1[i])
                {
                    team1.Remove(team1[i]);
                    PhotonNetwork.Destroy(unit.gameObject);
                }
            }
        }
        else if(team == 2)
        {
            for (int i = 0; i < team2.Count; i++)
            {
                if (unit == team2[i])
                {
                    team2.Remove(team2[i]);
                    PhotonNetwork.Destroy(unit.gameObject);
                }
            }
        }
    }
}
