using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using System;

public class HistoryProducts : MonoBehaviour
{
    public GameObject historialMenu;
    private Product pr;
    private YearProgress yp;
    private bool historyMenuActive;
    public TMP_Text historial;

    public List<Tuple<string, int, int>> historialList = new List<Tuple<string, int, int>>();

    // Start is called before the first frame update
    void Start()
    {
        pr = FindObjectOfType<Product>();
        yp = FindObjectOfType<YearProgress>();
        historyMenuActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (historialMenu.activeSelf && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Q)))
        {
            historialMenu.SetActive(false);
        }
    }

    public void ActiveMenu()
    {
        historyMenuActive = !historyMenuActive;
        historialMenu.SetActive(historyMenuActive);
    }

    public void AddOnProductcreation()
    {

        historialList.Add(new Tuple<string, int, int>(pr.productName.text, pr.profitAfterCreation(), yp.whatYear()));
        historial.text = "";

        foreach(Tuple<string, int, int> tuple in historialList)
        {
            historial.text += "Name: " + tuple.Item1 + "    Profit: " + tuple.Item2.ToString() + "    Year: " + tuple.Item3 + System.Environment.NewLine;
        }

    }
}
