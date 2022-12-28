using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits : MonoBehaviour
{
    private Transform trans;
    public Vector2 HRange = Vector2.zero;
    public Vector2 VRange = Vector2.zero;

    void LateUpdate()
    {
        trans.position = new Vector3(
            Mathf.Clamp(transform.position.x, VRange.x, VRange.y),
            Mathf.Clamp(transform.position.y, HRange.x, HRange.y),
            transform.position.z);
    }
    void Start()
    {
        trans = GetComponent<Transform>();
    }

  
    void Update()
    {

    }
}
