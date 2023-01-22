
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.ComponentModel.Design;
using System.Linq;
using Unity.VisualScripting;

public class Product : MonoBehaviour
{

    public float timeBtwDecreases;
    private float nextIncreaseTime;
    private MainGameManager mgm;

    private bool isLock;
    private bool isProductAcive;
    private bool isProductCreation;
    private bool isCalculation;
    private int creationTime;
    private int costByCreationTurn;
    private int profitAfterCreationTurn;
    private int profitTurn;
    private int maliciusTotalPoints;

    public TMP_Text creationTimeText;
    public TMP_Text turnsWithProfit;
    public TMP_Text maliciusPoints;
    public TMP_InputField productName;
    public TMP_Text historial;
    public GameObject bosssMenu;
    public TMP_Text buttonText;
    public UnityEngine.UI.Button button;

    private AgeGroup age;
    private Propagation prop;
    private DeadSin sin;
    private HistoryProducts hp;
    private ProgressBar pb;
    private Puntuacion punt;

    private int points;

    // Start is called before the first frame update
    void Start()
    {
        mgm = FindObjectOfType<MainGameManager>();
        age = FindObjectOfType<AgeGroup>();
        prop = FindObjectOfType<Propagation>();
        sin = FindObjectOfType<DeadSin>();
        hp = FindObjectOfType<HistoryProducts>();
        pb = FindObjectOfType<ProgressBar>();
        punt = FindObjectOfType<Puntuacion>();

        buttonText.text = "Calculate Product";

        creationTimeText.text = "0";
        turnsWithProfit.text = "0";
        maliciusPoints.text = "0";

        isProductCreation = false;
        isCalculation = true;
        isLock = false;

        creationTime=0;
        costByCreationTurn=0;
        profitAfterCreationTurn=0;
        profitTurn=0;
        maliciusTotalPoints=0;

}

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextIncreaseTime && isProductAcive)
        {
            nextIncreaseTime = Time.time + timeBtwDecreases;
            mgm.soul += profitAfterCreationTurn;
            profitTurn--;
        }
        else if(Time.time > nextIncreaseTime && (isProductCreation && creationTime >= 1))
        {
            nextIncreaseTime = Time.time + timeBtwDecreases;
            mgm.soul -= costByCreationTurn;
            creationTime -= 1;
            creationTimeText.text = creationTime.ToString();

        }
        else if (isProductCreation && creationTime < 1)
        {
            isProductCreation = false;
            isProductAcive = true;
            isLock = false;
            button.interactable = true;
            CancelCreation();   
        }
        else if (isProductAcive && profitTurn < 1)
        {
            isProductAcive = false;
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
            CalculateCreationTime(Random.Range(7,10));

            
            profitAfterCreationTurn = RandEmpl() * computePoints()/100 + computePoints();
            costByCreationTurn = profitAfterCreationTurn / 3;

            creationTimeText.text = creationTime.ToString();
            turnsWithProfit.text = profitTurn.ToString();

            buttonText.text = "Create Product";
            isCalculation = false;

        }
        else if (button.onClick != null && isCalculation==false)
        {
            if ((RandEmpl() * computePoints() / 100 + computePoints()) != profitAfterCreationTurn)
            {
                CancelCreation();
            }
            else
            {
                pb.increseProgress(maliciusTotalPoints * 0.01f);
                isProductCreation = true;
                isLock = true;
                buttonText.text = "You need to wait";
                button.interactable = false;
                hp.AddOnProductcreation();
            }
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

    public void CalculateMaliciusPoints(int minMalicius, int maxMalicius)  
    {

        maliciusTotalPoints = Random.Range(minMalicius, maxMalicius);

        //string sWord1 = minMalicius.ToString();
        string sWord2 = maxMalicius.ToString();

        maliciusPoints.text = "Up to "+sWord2;
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
    public int computePoints()
    {
        points = age.obtainAgeInfluence() + prop.obtainPropInfluence() + sin.obtainSinInfluence();
        if (points < 15)
        {
            CalculateMaliciusPoints(1, 5);
            profitTurn = Random.Range(2, 6);
        }
        else if (points >= 15 && points < 25)
        {
            CalculateMaliciusPoints(2, 8);
            profitTurn = Random.Range(4, 8);
        }
        else
        {
            CalculateMaliciusPoints(4, 12);
            profitTurn = Random.Range(5, 10);
        }
        return points;
    }

    public int RandEmpl()
    {
        int bonification = 0;
        if (mgm.employeesNum == 1)
        {
            bonification = Random.Range(0, 20);
        }
        else if (mgm.employeesNum == 2)
        {
            bonification = Random.Range(10, 30);
        }
        else if (mgm.employeesNum == 3)
        {
            bonification = Random.Range(20, 40);
        }
        else if (mgm.employeesNum == 4)
        {
            bonification = Random.Range(30, 50);
        }
        else if (mgm.employeesNum == 4)
        {
            bonification = Random.Range(40, 60);
        }
        return bonification;
    }

    public void Randomize()
    {
        int random = Random.Range(0, 5);
        if (random == 0)
        {
            productName.text = "The Divine Vow";
        }
        if (random == 1)
        {
            productName.text = "The Iron Golem";
        }
        if (random == 2)
        {
            productName.text = "The Catastrophe";
        }
        if (random == 3)
        {
            productName.text = "The Devil's Grimace";
        }
        if (random == 4)
        {
            productName.text = "The Face of Death";
        }
        if (random == 5)
        {
            productName.text = "The Demon Horns";
        }
    }

    public int profitAfterCreation()
    {
        return profitAfterCreationTurn;
    }
}
