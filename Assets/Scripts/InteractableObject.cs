using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

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
