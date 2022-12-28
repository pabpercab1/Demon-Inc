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
        if (Input.GetKey(KeyCode.E))
        {
            OnInteract();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            OnInteractClose();
        }
    }
    private void OnInteract()
    {
        Debug.Log("Clicked");
        menu.SetActive(true);
    }
    public void OnInteractClose()
    {
        Debug.Log("Clicked");
        menu.SetActive(false);
    }
}
