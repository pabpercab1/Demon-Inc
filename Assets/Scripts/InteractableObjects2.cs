using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InteractableObjects2 : MonoBehaviour
{
    public bool isInRange;
    public GameObject menu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                if (menu.activeSelf)
                {
                    OnInteractClose();
                }
                else OnInteract();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Trigger")
        {
            isInRange = true;
            Debug.Log("collision");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Trigger")
        {
            isInRange = false;
            Debug.Log("No collision");
        }
    }

    private void OnInteract()
    {
        menu.SetActive(true);
    }
    private void OnInteractClose()
    {
        menu.SetActive(false);
    }
}
