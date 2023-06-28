using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float direction;
    [SerializeField] private float speed = 200f;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private bool CheckGround;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private bool isFacing = true;

    private void Awake()
    {
        player = new PlayerController();
        player.Enable();

        player.Map.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };
        player.Map.Jump.performed += ctx => Jump();
    }
  
 
    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, rb.velocity.y);
        if (isFacing && direction < 0 || !isFacing && direction > 0)

            
         Flip();
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    void Flip()
    {
        isFacing = !isFacing;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
   

}
