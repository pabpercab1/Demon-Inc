using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employees : MonoBehaviour
{
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
        if (Time.time > nextDecreaseTime)
        {
            nextDecreaseTime = Time.time + timeBtwDecreases;
            mgm.soul -= soulsDecrease;
            Debug.Log("se esta quitanmdo dinero");
        }
        
    }

}
