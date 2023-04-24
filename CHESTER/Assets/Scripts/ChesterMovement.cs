using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChesterMovement : MonoBehaviour
{
    //Variables moverse
    private float horizontal;
    
    //Varuables dash
    
    private float speed = 2f;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 5f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    
    //Variables salto
    [SerializeField] private float jumpingPower = 4f;
    private bool doubleJump;
    
    //Variable flip
    private bool isFacingRight = true;
    
    //Objetos
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    public Animator animator;

    void Update()
    {
        if (isDashing)
        {
            return;
        }
        
        //Movimiento hacia los lados
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed_new",Mathf.Abs(horizontal));
        

        //Para que te deje hacer el doble salto una vez que tocas el suelo
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        
        //Si se intenta saltar y estas en el suelo realiza accion
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                animator.SetBool("Jump_new",true);
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                doubleJump = !doubleJump;
            }

        }

        //Animación cuando saltas
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            animator.SetBool("Jump_new",true);
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        
        //Si intentas deslizarte y puedes hacerlo, llama al método Dash()
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        
        //Llamo al método flip
        Flip();
    }

    //Metodo util para arreglar problemas del juego en ejecucion
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        //Marcamos la velocidad
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    //Devuelve un boolean que nos dira si el personaje esta tocando el suelo o no
    private bool IsGrounded()
    {
        animator.SetBool("Jump_new",false);
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
    }

    //Metodo para cambiar la orintación del jugador
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    
    
    //Método para deslizarse
    private IEnumerator Dash()
    {
        animator.SetTrigger("Dash_new");
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
