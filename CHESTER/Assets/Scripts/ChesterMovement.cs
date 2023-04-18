using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChesterMovement : MonoBehaviour
{
    //Variables
    private float horizontal;
    private float speed = 2f;
    [SerializeField] private float jumpingPower = 4f;
    private bool isFacingRight = true;
    private bool doubleJump;
    
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 5f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

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
        
        //Suavizar la entrada de teclado y devuelve 0,1 o -1 dependiendo de la direccion del personaje
        horizontal = Input.GetAxisRaw("Horizontal");
        
        //Marcar animacion de idle y correr
        animator.SetFloat("Speed_new",Mathf.Abs(horizontal));

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

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            animator.SetBool("Jump_new",true);
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        
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

    //Metodo para cambiar la posicion del PJ dependiendo de su direccion mediante isFacingRight
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
