using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class BuildingManager : MonoBehaviour
{
    public float money;
    public int team;

    public TextMeshProUGUI textMeshPro;
    public GameManager gameManager;
    [SerializeField] GameObject grid;
    [SerializeField] Camera cam;
    [SerializeField] LayerMask Obstacles;
    [SerializeField] Color canPlaceColor;
    [SerializeField] Color cantPlaceColor;
    [SerializeField] Color placedColor;
    GameObject BuildingObj;

    bool canPlace;

    void Start()
    {
        team = PhotonNetwork.LocalPlayer.ActorNumber;
    }

    public void chooseBuilding(Building building)
    {
        if(money - building.cost >= 0)
        {
            grid.SetActive(true);
            BuildingObj = PhotonNetwork.Instantiate(building.obj.name, transform.position, Quaternion.Euler(new Vector3(90, 0 , 0)));
            BuildingObj.GetComponent<BuildingController>().team = team;
        }
    }

    void Update()
    {
        team = PhotonNetwork.LocalPlayer.ActorNumber;
        textMeshPro.text = "Z - " + money.ToString();
        if (BuildingObj != null)
        {
            grid.SetActive(true);
            if (Physics.BoxCast(BuildingObj.transform.position, BuildingObj.transform.localScale, Vector3.down, Quaternion.identity, 1, Obstacles))
            {
                canPlace = false;
            }
            else
            {
                canPlace = true;
            }

            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mousePosSnapped = new Vector3(Mathf.Round(mousePos.x), 1, Mathf.Round(mousePos.z));
            Vector3 mousePosSmooth = new Vector3(mousePos.x, 1, mousePos.z);
            grid.transform.position = mousePosSmooth;
            BuildingObj.transform.position = mousePosSnapped;
            if (Input.GetKeyDown(KeyCode.LeftBracket))
            {
                BuildingObj.transform.eulerAngles -= new Vector3(0, 90, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightBracket))
            {
                BuildingObj.transform.eulerAngles += new Vector3(0, 90, 0);
            }
            BuildingObj.GetComponent<BuildingController>().enabled = false;
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                PhotonNetwork.Destroy(BuildingObj);
            }
        }
        else
        {
            grid.SetActive(false);
        }

        if (canPlace && BuildingObj != null)
        {
            BuildingObj.GetComponent<SpriteRenderer>().color = canPlaceColor;
            if (Input.GetMouseButtonDown(0))
            {
                BuildingObj.GetComponent<SpriteRenderer>().color = placedColor;
                BuildingObj.GetComponent<BuildingController>().enabled = true;
                BuildingObj.GetComponent<BuildingController>().gameManager = gameManager;
                BuildingObj.GetComponent<BuildingController>().manager = this;
                money -= BuildingObj.GetComponent<BuildingController>().buildingType.cost;
                BuildingObj = null;
                canPlace = false;
            }
        }
        else if(BuildingObj != null)
        {
            BuildingObj.GetComponent<SpriteRenderer>().color = cantPlaceColor;
        }
    }
}
