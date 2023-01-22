using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    private Propagation prop;
    private DeadSin sin;
    private AgeGroup age;
    private Product product;
    private MainGameManager mgm;

    private int points;
    // Start is called before the first frame update
    void Start()
    {
        prop = FindObjectOfType<Propagation>();
        sin = FindObjectOfType<DeadSin>();
        age = FindObjectOfType<AgeGroup>();
        product = FindObjectOfType<Product>();
        mgm = FindObjectOfType<MainGameManager>();

        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int computePoints()
    {
        points = age.obtainAgeInfluence() + prop.obtainPropInfluence() + sin.obtainSinInfluence();
        if (points >= 9 && points <15)
        {
            product.CalculateMaliciusPoints(1,5);
        }
        else if (points >= 15 && points < 25)
        {
            product.CalculateMaliciusPoints(2, 8);
        } 
        else product.CalculateMaliciusPoints(4, 12);

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
}
