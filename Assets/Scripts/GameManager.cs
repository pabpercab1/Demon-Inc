using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int souls;
    public Text soulDisplay;
    public GameObject hired;
    public int salary;
    public TMP_Text buttonText;

    void Update()
    {
        soulDisplay.text = souls.ToString();
        if (souls <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void HireEmployee()
    {
        if (hired.activeSelf)
        {
            hired.SetActive(false);
            souls += salary / 3;
            buttonText.text = "Hire";
        }
        else if (souls >= salary)
        {
            hired.SetActive(true);
            souls -= salary;
            buttonText.text = "Fire";
        }
    }
}
