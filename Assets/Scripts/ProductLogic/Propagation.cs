using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propagation : MonoBehaviour
{
    public TMPro.TMP_Dropdown PropDropdown;
    private int PropInfluence;

    List<string> names = new List<string>()
    {
        "Social Media", "Communication", "Political Speech", "Weather", "Dreams", "Advertisements", "Mobile Applications"
    };

    private void Start()
    {
        PopulateList();
        PropInfluence = 5;
    }

    void PopulateList()
    {
        PropDropdown.AddOptions(names);
    }

    public void ManageSin_index(int index)
    {
        if (index == 0)
        {
            PropInfluence = 10;
            Debug.Log("OPCION 0");
        }
        else if (index == 1)
        {
            PropInfluence = 4;
            Debug.Log("OPCION 1");
        }
        else if (index == 2)
        {
            PropInfluence = 5;
            Debug.Log("OPCION 2");
        }
        else if (index == 3)
        {
            PropInfluence = 2;
            Debug.Log("OPCION 4");
        }
        else if (index == 4)
        {
            PropInfluence = 4;
            Debug.Log("OPCION 5");
        }
        else if (index == 5)
        {
            PropInfluence = 7;
            Debug.Log("OPCION 6");
        }
        else if (index == 6)
        {
            PropInfluence = 9;
            Debug.Log("OPCION 7");
        }
        else PropInfluence = 0;
    }
    public int obtainPropInfluence()
    {
        Debug.Log("LLAMADA OBTAIN INFLUENCE" + PropInfluence.ToString());
        return PropInfluence;
    }
}
