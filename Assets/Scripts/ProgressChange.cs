using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressChange : MonoBehaviour
{
    public TMP_Text demons;
    public TMP_Text angels;

    private ProgressBar pg;

    private void Start()
    {
        pg = FindObjectOfType<ProgressBar>();
        //demons = gameObject.GetComponent<TMP_Text>();
        demons.text = "00";
        angels.text = "100";
    }
    public void UpdateCounter()
    {
        float demonsText = pg.getProgress()*100f;
        float angelstext = 100f - demonsText;

        int realDemon = (int)demonsText;
        int realAngel = (int)angelstext;

        demons.text = realDemon.ToString();
        angels.text = realAngel.ToString();
    }
}
