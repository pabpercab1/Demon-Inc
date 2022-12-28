using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int souls;
    public Text soulDisplay;
    
    void Update()
    {
        soulDisplay.text = souls.ToString();
    }

    public void HireEmployee(Employees employee)
    {
        if(souls >= employee.salary)
        {
            souls -= employee.salary;
        }
    }
}
