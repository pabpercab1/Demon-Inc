using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoreHelper : MonoBehaviour
{
    public GameObject secretario;
    public GameObject dialoguePanel;
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
        }
        else
        {
            SceneManager.LoadScene("Tutorial");
            gameObject.SetActive(false);
        }   
    }

}
