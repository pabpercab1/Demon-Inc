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
    private ProgressBar pb;



    void Start()
    {
        mgm = FindObjectOfType<MainGameManager>();
        pb = FindObjectOfType<ProgressBar>();

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
        }
        
    }

    public void HireEmployee()
    {
            if (hired.activeSelf)
            {
                hired.SetActive(false);
                mgm.soul += salary / 3;
                buttonText.text = "Hire";
                mgm.employeesNum -= 1;
                pb.decreaseProgress(Random.Range(4, 6) * 0.01f);

            }
            else if (mgm.soul >= salary)
            {
                hired.SetActive(true);
                mgm.soul -= salary;
                buttonText.text = "Fire";
                mgm.employeesNum += 1;
                Debug.Log(hired.name);
                pb.increseProgress(Random.Range(2, 6) * 0.01f);
            }

    }
}