using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //public TMP_Text soulDisplay;
   // public int soul;
    public GameObject hired;
    public TMP_Text buttonText;
    public Button button;

    public int salary;
    public int soulsDecrease;
    public float timeBtwDecreases;
    private float nextDecreaseTime;

    private MainGameManager mgm;




    void Start()
    {
        mgm = FindObjectOfType<MainGameManager>();
        
    }

    public void Update()
    {
        if (mgm.soul < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (Time.time > nextDecreaseTime && hired.activeSelf)
        {
            nextDecreaseTime = Time.time + timeBtwDecreases;
            mgm.soul -= soulsDecrease;
            Debug.Log("se esta quitanmdo dinero");
        }
    }

    public void HireEmployee()
    {
        if (button.onClick != null)
        {
            if (hired.activeSelf)
            {
                hired.SetActive(false);
                mgm.soul += salary / 3;
                buttonText.text = "Hire";
                mgm.employeesNum -= 1;

            }
            else if (mgm.soul >= salary)
            {
                hired.SetActive(true);
                mgm.soul -= salary;
                buttonText.text = "Fire";
                mgm.employeesNum += 1;
                
            }
        }
   
    }
}
