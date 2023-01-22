using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLogic : MonoBehaviour
{

    public TMP_Text wintext;

    // Start is called before the first frame update
    void Start()
    {
        wintext.text = MainGameManager.staticSouls.ToString()+" souls";
    }

    // Update is called once per frame
    void Update()
    {
        wintext.text = MainGameManager.staticSouls.ToString() + " souls";
    }
}
