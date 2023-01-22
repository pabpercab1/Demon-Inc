using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YearProgress : MonoBehaviour
{
    public TMP_Text yearCounter;
    private int yearCounterIndex;
    private float nextDecreaseTime;
    private float timeBtwDecreases;

    // Start is called before the first frame update
    void Start()
    {
        yearCounterIndex = 666;
        yearCounter.text = yearCounterIndex.ToString();

        timeBtwDecreases = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextDecreaseTime)
        {
            nextDecreaseTime = Time.time + timeBtwDecreases;
            yearCounterIndex--;

            yearCounter.text = yearCounterIndex.ToString();
        }

        if(yearCounterIndex <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public int whatYear()
    {
        return yearCounterIndex;
    }
}
