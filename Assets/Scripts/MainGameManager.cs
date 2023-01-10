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

    private void Start()
    {
        soulDisplay.text = soul.ToString();
    }
    void Update()
    {
        if (soul < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        Debug.Log(soul.ToString());

        soulDisplay.text = soul.ToString();
    }
}
