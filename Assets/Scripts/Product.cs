using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Product : MonoBehaviour
{
    public Button button;

    public float timeBtwDecreases;
    private float nextIncreaseTime;
    private MainGameManager mgm;

    private bool isProductAcive;
    private bool isProductCreation;
    private int developTimeProduct;
    private int creationTime;
    // Start is called before the first frame update
    void Start()
    {
        mgm = FindObjectOfType<MainGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextIncreaseTime && isProductAcive)
        {
            nextIncreaseTime = Time.time + timeBtwDecreases;
            mgm.soul += 1001;
        }
        else if(Time.time > nextIncreaseTime && (isProductCreation && creationTime >= 1))
        {
            nextIncreaseTime = Time.time + timeBtwDecreases;
            mgm.soul -= 11;
            creationTime -= 1;

        }
        else if(isProductCreation && creationTime <1)
        {
            isProductCreation = false;
            isProductAcive = true;
        }
    }
    public void ProductCreation()
    {
        if (button.onClick != null)
        {
            isProductCreation = true;
            creationTime = 4;
            //if (hired.activeSelf)
            //{
            //    hired.SetActive(false);
            //    mgm.soul += salary / 3;
            //    buttonText.text = "Hire";

            //}
            //else if (mgm.soul >= salary)
            //{
            //    hired.SetActive(true);
            //    mgm.soul -= salary;
            //    buttonText.text = "Fire";


            //}
        }

    }
}
