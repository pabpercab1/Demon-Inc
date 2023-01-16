using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Product : MonoBehaviour
{

    public float timeBtwDecreases;
    private float nextIncreaseTime;
    private MainGameManager mgm;

    private bool isLock;
    private bool isProductAcive;
    private bool isProductCreation;
    private bool isCalculation;
    private int developTimeProduct;
    public int creationTime;
    public int costByCreationTurn;
    public int profitAfterCreationTurn;
    public int profitTurn;
    public int maliciusTotalPoints;

    public TMP_Text creationTimeText;
    //public TMP_Text costByTurnText;
    //public TMP_Text profitText;
    public TMP_Text turnsWithProfit;
    public TMP_Text maliciusPoints;

    public GameObject bosssMenu;
    public TMP_Text buttonText;
    public UnityEngine.UI.Button button;

    // Start is called before the first frame update
    void Start()
    {
        mgm = FindObjectOfType<MainGameManager>();
        buttonText.text = "Calculate Product";

        creationTimeText.text = "0";
        turnsWithProfit.text = "0";
        maliciusPoints.text = "0";

        isProductCreation = false;
        isCalculation = true;
        isLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextIncreaseTime && isProductAcive)
        {
            nextIncreaseTime = Time.time + timeBtwDecreases;
            mgm.soul += profitAfterCreationTurn;
        }
        else if (Time.time > nextIncreaseTime && (isProductCreation && creationTime >= 1))
        {
            nextIncreaseTime = Time.time + timeBtwDecreases;
            mgm.soul -= costByCreationTurn;
            creationTime -= 1;

        }
        else if (isProductCreation && creationTime < 1)
        {
            isProductCreation = false;
            isProductAcive = true;
            isLock = false;
        }


        if(!bosssMenu.activeSelf && (costByCreationTurn!=0 || maliciusTotalPoints!=0 || creationTime!=0))
        {
            CancelCreation();
        }
    }
    public void ProductCreation()
    {
        if (button.onClick != null && isCalculation)
        {
            CalculateCreationTime(100);

            costByCreationTurn = 11;
            profitAfterCreationTurn = 1001;
            profitTurn = 5;


            CalculateMaliciusPoints(1, 6);
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
            creationTimeText.text = creationTime.ToString();
            turnsWithProfit.text = profitTurn.ToString();

            buttonText.text = "Create Product";
            isCalculation = false;
        }
        else if (button.onClick != null && isCalculation==false)
        {
            isProductCreation = true;
            isLock = true;
            buttonText.text = "You need to wait";
            button.interactable = false;
        }

    }
    public void CancelCreation()
    {
        if (isLock == false)
        {
            buttonText.text = "Calculate Product";

            creationTimeText.text = "0";
            turnsWithProfit.text = "0";
            maliciusPoints.text = "0";

            isProductCreation = false;
            isCalculation = true;
        }
    }

    private void CalculateMaliciusPoints(int minMalicius, int maxMalicius)  
    {

        maliciusTotalPoints = Random.Range(minMalicius, maxMalicius);

        string sWord1 = minMalicius.ToString();
        string sWord2 = maxMalicius.ToString();

        maliciusPoints.text = sWord1+" to "+sWord2;
    }

    private void CalculateCreationTime(int originalCreationTime)
    {
        if (mgm.employeesNum > 0)
        {
            double discount = originalCreationTime * mgm.employeesNum * 0.1;
            creationTime = Mathf.RoundToInt((float)(originalCreationTime - discount));
        }
        else
        {
            creationTime = originalCreationTime;
        }
    }
}
