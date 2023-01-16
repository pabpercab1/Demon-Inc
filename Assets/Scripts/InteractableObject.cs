using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : Action_Menu
{
    public GameObject menu;
    public Image Image;

    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(menu.activeSelf) OnInteractClose();
            else OnInteract();
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) 
            || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) 
            || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            OnInteractClose();
        }
    }

    private void OnInteract()
    {
        menu.SetActive(true);
    }
    public void OnInteractClose()
    {
        menu.SetActive(false);
    }

  
}
