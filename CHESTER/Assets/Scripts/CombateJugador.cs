using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    private Animator animator;
    
    private Vector2 startPos;
    [Header("Vida")]
    [SerializeField] private float vida;
    [SerializeField] private BarradeVida barraDeVida;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        animator = GetComponent<Animator>();
        barraDeVida.inicializarBarraDeVida(vida);
    }

    public void TomarDano(float dano)
    {
        vida -= dano;
        barraDeVida.cambiarVidaActual(vida);
        if (vida<=0)
        {
            animator.SetTrigger("Muerte");
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void Die()
    {
        Respawn();
        vida = 6;
        barraDeVida.cambiarVidaActual(vida);
    }

    void Respawn()
    {
        transform.position = startPos;
        
    }
}
