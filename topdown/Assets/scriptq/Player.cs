using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;
    
    public Rigidbody2D rb;
    
    private Vector2 moveDirection;
    
    [SerializeField]
    public InputActionReference movement;

    private bool facingRight = true;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        animantion();

    }

    void FixedUpdate()
    {
        Move();
        
        if (moveDirection.x > 0 && !facingRight)
        {
            Flip();
        }
        
         if (moveDirection.x < 0 && facingRight)
        {
            Flip();
        }
    }
    
    
    void ProcessInput()
    {
        moveDirection = movement.action.ReadValue<Vector2>().normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed ,moveDirection.y * speed );

        
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    void animantion()
    {
       if(moveDirection != Vector2.zero)
        {
            animator.SetBool("IsMoving", true);
         }
        
        else
        {
           animator.SetBool("IsMoving", false); 
        }
    }
}

    
