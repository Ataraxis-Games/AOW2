using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VidTools.Vis;
using Photon.Pun;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float scrollSpeed;
    [SerializeField]
    int team;
    [SerializeField]
    GameManager gameManager;

    private void Update()
    {
        Movement();
        Selection();
        team = PhotonNetwork.LocalPlayer.ActorNumber;
    }

    void Movement()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * movementSpeed;
        transform.position += input * Time.deltaTime * GetComponent<Camera>().orthographicSize;
        GetComponent<Camera>().orthographicSize -= (Input.mouseScrollDelta.y * scrollSpeed * GetComponent<Camera>().orthographicSize * Time.deltaTime);
    }

    Vector3 startPos;
    Vector3 endPos;
    void Selection()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPos = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            startPos = new Vector3(startPos.x, 1, startPos.z);
        }

        if(Input.GetMouseButton(0))
        {
            endPos = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            endPos = new Vector3(endPos.x, 1, endPos.z);
            gameManager.selectUnits(startPos, endPos, team);
            Draw.Cube((startPos + endPos) / 2, Quaternion.identity, (startPos - endPos), Color.Lerp(Color.green, Color.clear, 0.75f));
        }

        if(Input.GetMouseButtonDown(1))
        {
            Vector3 pos = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            pos = new Vector3(pos.x, 1, pos.z);
            gameManager.setUnitTargets(pos);
        }
    }
}
