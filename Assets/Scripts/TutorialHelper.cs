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
            if (index > 0)
            {
                full.SetActive(false);
                corner.SetActive(true);
                highlightEmp.SetActive(true);

            }
            if (index > 2)
            {
                highlightEmp.SetActive(false);
                highlightBoss.SetActive(true);
            }
            if (index > 4) 
            {
                highlightBoss.SetActive(false);
                corner.SetActive(false);
                full.SetActive(true);
                highlightRecord.SetActive(true);
            }
            if (index > 5)
            {
                highlightRecord.SetActive(false);
                highlightSouls.SetActive(true);
            }
            if (index > 6)
            {
                highlightSouls.SetActive(false);
                highlightYear.SetActive(true);
            }
            if (index > 7)
            {
                highlightYear.SetActive(false);
                highlightBar.SetActive(true);
            }
            if (index > 8)
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
            if (index < 5 && index >= 3)
            {
                full.SetActive(false);
                corner.SetActive(true);
                highlightBoss.SetActive(true);
                highlightRecord.SetActive(false);
            }
            if (index == 5)
            {
                highlightSouls.SetActive(false);
                highlightRecord.SetActive(true);
            }
            if (index == 6)
            {
                highlightYear.SetActive(false);
                highlightSouls.SetActive(true);
            }
            if (index == 7)
            {
                highlightBar.SetActive(false);
                highlightYear.SetActive(true);
            }
            if (index == 8)
            {
                highlightBar.SetActive(true);
            }
        }
        else
        {

        }

    }

}
