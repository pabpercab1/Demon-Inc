using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialHelper : MonoBehaviour
{
    public GameObject secretario;
    public GameObject dialoguePanel;
    public GameObject highlightEmp;
    public GameObject highlightBoss;
    public TMP_Text textComponent;
    public string[] lines;

    public float textSpeed;
    private int index;
   
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }


    void Update()
    {
     if (Input.GetMouseButtonDown(0))
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
            if (index > 0)
            {
                secretario.SetActive(false);
                highlightEmp.SetActive(true);

            }
            if (index > 2)
            {
                highlightEmp.SetActive(false);
                highlightBoss.SetActive(true);
            }
            if (index > 3) 
            { 
                highlightBoss.SetActive(false);
                secretario.SetActive(true);
            }
        }
        else
        {
            SceneManager.LoadScene("Scene1");
            gameObject.SetActive(false);
        }   
    }

}
