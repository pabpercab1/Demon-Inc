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

    private void Start()
    {
        soulDisplay.text = soul.ToString();
        employeesNum = 0;
    }
    void Update()
    {
        if (soul < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        soulDisplay.text = soul.ToString();
    }
}
