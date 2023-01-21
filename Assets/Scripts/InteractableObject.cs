using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UI;

public class InteractableObject : Action_Menu
{
    public GameObject menu;
    public Image Image;
    public GameObject highlight;
    public GameObject player;

    private float distance;
    protected override void OnCollided(GameObject collidedObject)
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 2.3)
        {
            highlight.SetActive(true);

        }
        else
        {
            highlight.SetActive(false);
            if (menu.activeSelf)
            {
                menu.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (menu.activeSelf) OnInteractClose();
            else OnInteract();
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
