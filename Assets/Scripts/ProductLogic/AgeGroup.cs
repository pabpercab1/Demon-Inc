using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgeGroup : MonoBehaviour
{
    public TMPro.TMP_Dropdown ageDropdown;
    private int ageGroupInfluence;

    List<string> names = new List<string>()
    {
        "Children", "Teenagers", "Adults", "Eldery"
    };

    private void Start()
    {
        PopulateList();
        ageGroupInfluence = 3;
    }

    void PopulateList()
    {
        ageDropdown.AddOptions(names);
    }

    public void ManageAge_index(int index)
    {
        if (index == 0)
        {
            ageGroupInfluence = 3;
            Debug.Log("OPCION 0");
        }
        else if (index == 1)
        {
            ageGroupInfluence = 7;
            Debug.Log("OPCION 1");
        }
        else if (index == 2)
        {
            ageGroupInfluence = 10;
            Debug.Log("OPCION 2");
        }
        else if (index == 3)
        {
            ageGroupInfluence = 3;
            Debug.Log("OPCION 3");
        }
        else ageGroupInfluence = 0;
    }
    public int obtainAgeInfluence()
    {
        Debug.Log("LLAMADA OBTAIN INFLUENCE" + ageGroupInfluence.ToString());
        return ageGroupInfluence;
    }
}
