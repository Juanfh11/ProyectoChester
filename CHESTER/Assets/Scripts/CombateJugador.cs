using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    //Variables
    private Animator animator;
    private Vector2 startPos;
    [Header("Vida")]
    [SerializeField] private float vida;
    [SerializeField] private BarradeVida barraDeVida;
    public AudioClip sonidoMuerte;
    public AudioClip sonidoDano;

    //Metodo Start
    void Start()
    {
        startPos = transform.position;
        animator = GetComponent<Animator>();
        barraDeVida.inicializarBarraDeVida(vida);
    }

    /**
     * Metodo que sirve para restarle la vida a Chester y si su vida es 0 o menor se reproduce su muerte
     */
    public void TomarDano(float dano)
    {
        vida -= dano;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sonidoDano);
        barraDeVida.cambiarVidaActual(vida);
        if (vida<=0)
        {
            animator.SetTrigger("Muerte");
            Camera.main.GetComponent<AudioSource>().PlayOneShot(sonidoMuerte);
        }

    }
    
    /**
     * Metodo que recupera la vida cuando tocas una pocion
     */
    public void RecuperaVida(float sumaVida)
    {
        if ((vida += sumaVida) < 10)
        {
            vida += sumaVida;
        }
        else
        {
            vida = 10;
        }
        barraDeVida.cambiarVidaActual(vida);
    }
    
    //Metodo que se llama cuando el jugador muere
    void Die()
    {
        vida = 10;
        barraDeVida.cambiarVidaActual(vida);
    }
}
