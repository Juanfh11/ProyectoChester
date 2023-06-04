using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //variables
    private Vector2 startPos;
    [SerializeField] BarradeVida vida;
    
    //inicializacion de variables
    private void Start()
    {
        startPos = transform.position;
        vida = GetComponent<BarradeVida>();
    }

    //trigger para ejecura el metodo die
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("End"))
        {
            Die();
        }
    }

    //metodo para el respawn del jugador al morir
    void Die()
    {
        Respawn();
    }

    //metodo para hacer respawn en la posicion donde comienza el jugador
    void Respawn()
    {
        transform.position = startPos;
    }
}
