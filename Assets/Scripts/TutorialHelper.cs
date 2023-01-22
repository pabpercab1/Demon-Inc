using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialHelper : MonoBehaviour
{
    public GameObject full;
    public GameObject corner;
    public GameObject highlightEmp;
    public GameObject highlightBoss;
    public GameObject highlightRecord;
    public GameObject highlightYear;
    public GameObject highlightSouls;
    public GameObject highlightBar;
    public GameObject highlightLossTurns;
    public GameObject highlightProfitTurns;
    public GameObject highlightPoints;
    public GameObject highlightOptions;
    public GameObject bossMenu;




    public TMP_Text fullScreenText;
    public TMP_Text cornerText;
    public string[] lines;

    public float textSpeed;
    private int index;
   
    void Start()
    {
        fullScreenText.text = string.Empty;
        cornerText.text = string.Empty;
        StartDialogue();
    }


    void Update()
    {
        Debug.Log(index.ToString());
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(fullScreenText.text == lines[index] || cornerText.text == lines[index])
            {
                NextLine();
            }
            else if (fullScreenText.IsActive())
            {
                StopAllCoroutines();
                fullScreenText.text = lines[index];
            }
            else
            {
                StopAllCoroutines();
                cornerText.text = lines[index];
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (fullScreenText.text == lines[index] || cornerText.text == lines[index])
            {
                PreviousLine();

            }
            else if (fullScreenText.IsActive())
            {
               StopAllCoroutines();
               fullScreenText.text = lines[index];
            }
            else
            {
                StopAllCoroutines();
                cornerText.text = lines[index];
            }
        }
    
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Skip();
        }
    }

    public void Skip()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            if (fullScreenText.IsActive())
            {
                fullScreenText.text += c;
            }
            else cornerText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            fullScreenText.text = string.Empty;
            cornerText.text = string.Empty;
            StartCoroutine(TypeLine());
            if (index > 0 && index < 3)
            {
                full.SetActive(false);
                corner.SetActive(true);
                highlightEmp.SetActive(true);

            }
            if (index == 3)
            {
                highlightEmp.SetActive(false);
                highlightBoss.SetActive(true);
            }
            if (index == 4) 
            {
                highlightBoss.SetActive(false);
                bossMenu.SetActive(true);
                highlightPoints.SetActive(true);
            }
            if (index == 5)
            {
                highlightPoints.SetActive(false);
                highlightOptions.SetActive(true);
            }
            if (index == 6)
            {
                highlightOptions.SetActive(false);
                highlightLossTurns.SetActive(true);
                highlightPoints.SetActive(true);
            }
            if (index == 7)
            {
                highlightLossTurns.SetActive(false);
                highlightPoints.SetActive(false);
                highlightProfitTurns.SetActive(true);
            }
            if (index == 8)
            {
                highlightProfitTurns.SetActive(false);
                bossMenu.SetActive(false);
                corner.SetActive(false);
                full.SetActive(true);
                highlightRecord.SetActive(true);
            }
            if (index == 9)
            {
                highlightRecord.SetActive(false);
                highlightSouls.SetActive(true);
            }
            if (index == 10)
            {
                highlightSouls.SetActive(false);
                highlightYear.SetActive(true);
            }
            if (index == 11)
            {
                highlightYear.SetActive(false);
                highlightBar.SetActive(true);
            }
            if (index == 12)
            {
                highlightBar.SetActive(false);
            }
        }
        else
        {
            SceneManager.LoadScene("Scene1");
            gameObject.SetActive(false);
        }   
    }

   void PreviousLine()
    { 
        if (index > 0)
        {
            index--;
            fullScreenText.text = string.Empty;
            cornerText.text = string.Empty;
            StartCoroutine(TypeLine());
            if (index == 0)
            {
                corner.SetActive(false);
                highlightEmp.SetActive(false);
                full.SetActive(true);
            }
            if (index < 3 && index != 0)
            {
                highlightBoss.SetActive(false);
                highlightEmp.SetActive(true);
            }
            if (index == 3)
            {
                highlightPoints.SetActive(false);
                bossMenu.SetActive(false);
                highlightBoss.SetActive(true);
            }
            if (index == 4)
            {
                highlightOptions.SetActive(false);
                highlightPoints.SetActive(true);
            }
            if (index == 5)
            {
                highlightLossTurns.SetActive(false);
                highlightPoints.SetActive(false);
                highlightOptions.SetActive(true);
            }
            if (index == 6)
            {
                highlightProfitTurns.SetActive(false);
                highlightPoints.SetActive(true);
                highlightLossTurns.SetActive(true);
            }
            if (index == 7)
            {
                full.SetActive(false);
                highlightRecord.SetActive(false);
                corner.SetActive(true);
                bossMenu.SetActive(true);
                highlightProfitTurns.SetActive(true);
            }
            if (index == 8)
            {
                highlightSouls.SetActive(false);
                highlightRecord.SetActive(true);
            }
            if (index == 9)
            {
                highlightYear.SetActive(false);
                highlightSouls.SetActive(true);
            }
            if (index == 10)
            {
                highlightBar.SetActive(false);
                highlightYear.SetActive(true);
            }
            if (index == 11)
            {
                highlightBar.SetActive(true);
            }
        }
        else
        {

        }

    }

}
