using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Vector2 startPos;
    [SerializeField] BarradeVida vida;
    
    private void Start()
    {
        startPos = transform.position;
        vida = GetComponent<BarradeVida>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("End"))
        {
            Die();
        }
    }

    void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = startPos;
    }
}
