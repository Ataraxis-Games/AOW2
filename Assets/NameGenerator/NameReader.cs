using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using System.Linq;

public class NameReader : MonoBehaviour
{
    [SerializeField] TextAsset firstnamestxt;
    public List<string> firstnames = new List<string>();
    [SerializeField] TextAsset middlenamestxt;
    public List<string> middlenames = new List<string>();
    [SerializeField] TextAsset lastnamestxt;
    public List<string> lastnames = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        firstnames = firstnamestxt.text.Split().ToList();
        for(int i = 0; i < firstnames.Count; i++) 
        {
            if (firstnames[i] == "")
            {
                firstnames.Remove(firstnames[i]);
            }
        }

        middlenames = middlenamestxt.text.Split().ToList();
        for (int i = 0; i < middlenames.Count; i++)
        {
            if (middlenames[i] == "")
            {
                middlenames.Remove(middlenames[i]);
            }
        }

        lastnames = lastnamestxt.text.Split().ToList();
        for (int i = 0; i < lastnames.Count; i++)
        {
            if (lastnames[i] == "")
            {
                lastnames.Remove(lastnames[i]);
            }
        }
    }
}
