using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed;
 
    private float _vInput;
    private float _hInput;
    private BoxCollider2D z_BoxCollider;
    private Animator animator;

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        // Input X,Y
        float dx = Input.GetAxis("Horizontal") * speed;
        float dy = Input.GetAxis("Vertical") * speed;

        Vector2 movement = new Vector2(dx * Time.deltaTime, dy * Time.deltaTime);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        // Flip it
        if (movement.x > 0)
        {
            transform.localScale = new Vector3(-5, 5, 1);
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(5, 5, 1);
        }

        // Collision
        RaycastHit2D castResult;
        // X
        castResult = Physics2D.BoxCast(transform.position, z_BoxCollider.size, 0, new Vector2(dx, 0), Mathf.Abs(dx * Time.deltaTime * speed), LayerMask.GetMask("BlockMove"));
        if (castResult.collider)
        {
            movement.x = 0;
        }
        // Y
        castResult = Physics2D.BoxCast(transform.position, z_BoxCollider.size, 0, new Vector2(0, dy), Mathf.Abs(dy * Time.deltaTime * speed), LayerMask.GetMask("BlockMove"));
        if (castResult.collider)
        {
            movement.y = 0;
        }

        bool isWalking = movement.magnitude > 0;
        // z_Animator.SetBool("skeleton_walking", isWalking);

        transform.Translate(movement * Time.deltaTime * speed);

    }

    // Start is called before the first frame update
    void Start()
    {
        z_BoxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
