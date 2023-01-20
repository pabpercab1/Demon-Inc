using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoreHelper : MonoBehaviour
{
    public GameObject secretario;
    public GameObject dialoguePanel;
    public TMP_Text textComponent;
    public string[] lines;
    public Button button;

    public float textSpeed;
    private int index;
   
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }


    void Update()
    {
         if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
         {
                if(textComponent.text == lines[index])
                {
                    NextLine();

                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
         }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (textComponent.text == lines[index])
            {
                PreviousLine();

            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
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
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            SceneManager.LoadScene("Tutorial");
            gameObject.SetActive(false);
        }   
    }

    void PreviousLine()
    {
        if (index > 0)
        {
            index--;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

}
