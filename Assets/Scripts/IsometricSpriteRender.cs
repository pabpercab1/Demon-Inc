using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricSpriteRender : MonoBehaviour
{
    void Update()
    {
        GetComponent<Renderer>().sortingOrder = (int)(transform.position.y * -1.7); 
    }
}
