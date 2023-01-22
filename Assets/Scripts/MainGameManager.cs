using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainGameManager : MonoBehaviour
{
    public TMP_Text soulDisplay;
    public int soul;
    public int employeesNum;

    public static int staticSouls;

    private ProgressBar pg;

    private void Start()
    {
        pg = FindObjectOfType<ProgressBar>();
        soulDisplay.text = soul.ToString();
        employeesNum = 0;
        staticSouls = 0;
    }
    void Update()
    {
        if (soul < 0)
        {
            soulDisplay.text = "0";
            SceneManager.LoadScene("GameOver");
        }
        else if (pg.getProgress() >= 1)
        {
            staticSouls = soul;
            SceneManager.LoadScene("Win");
        }

        else soulDisplay.text = soul.ToString();
    }
}
