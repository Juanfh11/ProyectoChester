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
    
    public AudioClip sonidoMuerte;
    public AudioClip sonidoDano;

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
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sonidoDano);
        barraDeVida.cambiarVidaActual(vida);
        if (vida<=0)
        {
            animator.SetTrigger("Muerte");
            Camera.main.GetComponent<AudioSource>().PlayOneShot(sonidoMuerte);
        }

    }
    
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
