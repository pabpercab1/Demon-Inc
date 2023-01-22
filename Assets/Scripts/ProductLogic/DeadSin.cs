using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSin : MonoBehaviour
{
    public TMPro.TMP_Dropdown SinDropdown;
    private int DeadSinInfluence;

    List<string> names = new List<string>()
    {
        "Vanity", "Lust", "Greed", "Anger", "Gluttony", "Envy", "Lazyness"
    };

    private void Start()
    {
        PopulateList();
        DeadSinInfluence = 3;
    }

    void PopulateList()
    {
        SinDropdown.AddOptions(names);
    }

    public void ManageSin_index(int index)
    {
        if (index == 0)
        {
            DeadSinInfluence = 3;
            Debug.Log("OPCION 0");
        }
        else if (index == 1)
        {
            DeadSinInfluence = 7;
            Debug.Log("OPCION 1");
        }
        else if (index == 2)
        {
            DeadSinInfluence = 9;
            Debug.Log("OPCION 2");
        }
        else if (index == 3)
        {
            DeadSinInfluence = 7;
            Debug.Log("OPCION 4");
        }
        else if (index == 4)
        {
            DeadSinInfluence = 6;
            Debug.Log("OPCION 5");
        }
        else if (index == 5)
        {
            DeadSinInfluence = 8;
            Debug.Log("OPCION 6");
        }
        else if (index == 6)
        {
            DeadSinInfluence = 10;
            Debug.Log("OPCION 7");
        }
        else DeadSinInfluence = 0;
    }
    public int obtainSinInfluence()
    {
        Debug.Log("LLAMADA OBTAIN INFLUENCE" + DeadSinInfluence.ToString());
        return DeadSinInfluence;
    }
}
