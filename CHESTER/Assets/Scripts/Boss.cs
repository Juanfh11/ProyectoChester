using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //Variables
    private Animator animator;
    public Rigidbody2D rb2d;
    public Transform jugador;
    private bool mirandoDerecha = true;

    [Header("Vida")]
    [SerializeField] private float vida;
    [SerializeField] private BarradeVida barraDeVida;

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float danoAtaque;

    public AudioClip sonidoMuerte;
    public AudioClip sonidoAparecer;
    public AudioClip sonidoAtaque;
    
    public GameObject chester;
    private bool iniciado;


    //Metodo Start, en el se asignan valor a algunas variables
    void Start()
    {
        iniciado = false;
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        barraDeVida.inicializarBarraDeVida(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    /**
     * Metodo Update
     * Se coje la distancia del enemigo al jugador y se activa el animator del enemigo si está a cierta distancia
     */
    void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position,jugador.position);
        animator.SetFloat("distanciaJugador",distanciaJugador);
        
        float distanceX = Mathf.Abs(chester.transform.position.x - transform.position.x);
        float distanceY = Mathf.Abs(chester.transform.position.y - transform.position.y);

        if ((distanceX < 3.5f && distanceX > -3.5f) && ((distanceY < 3.5f) && (distanceY > -3.5f)) && !iniciado)
        {
            iniciado = true;
            animator.enabled = true;
        }
    }

    /*
     * Metodo que resta la vida al enemigo y si su vida es menor o igual que 0 se llama a la animacion de muerte
     */
    public void tomarDano(float dano)
    {
        vida -= dano;
        barraDeVida.cambiarVidaActual(vida);
        if (vida<=0)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(sonidoMuerte);
            animator.SetTrigger("Muerte");
        }
    }

    //Metodo que destruye el objeto cuando se muere el enemigo
    private void Muerte()
    {
        Destroy(gameObject);
    }

    //Metodo que sirve para poner el sonido del enemigo al aparecer
    private void Aparecer()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sonidoAparecer);
    }

    //Metodo que sirve para que el enemigo esté mirando al jugador
    public void mirarJugador()
    {
        if ((jugador.position.x>transform.position.x && !mirandoDerecha) || (jugador.position.x<transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y+180,0);
        }
    }

    //Metodo que sirve para atacar a Chester y llama al método para restarle la vida
    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sonidoAtaque);
        foreach (Collider2D colision in objetos)
        {
            if (colision.CompareTag("Player"))
            {
                colision.GetComponent<CombateJugador>().TomarDano(danoAtaque);
            }
        }
    }

    //Metodo para imprimir el area de daño del enemigo
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position,radioAtaque);
    }
}
