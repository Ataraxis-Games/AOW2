using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiManager : MonoBehaviour
{
    public GameObject[] otherMenus;

    public void changeMenu(int menu)
    {
        foreach(GameObject g in otherMenus)
        {
            g.SetActive(false);
        }
        otherMenus[menu].SetActive(true);
    }
}
