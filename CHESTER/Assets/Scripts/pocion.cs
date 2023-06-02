using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class pocion : MonoBehaviour
{
    //Variables
    [SerializeField] private Transform controlador;
    [SerializeField] private GameObject player;
    Rigidbody2D rigidbody2D;
    [SerializeField] private Vector2 dimensionesCaja;
    [SerializeField] private Transform posicionCaja;
    [SerializeField] private int vida;
    public AudioClip sonido;
    
    //Metod Start
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    /**
     * Metodo Update
     * Se comprueba si el jugador ha colisionado con la pocion, si es así se llaman a los metodos para sumar la vida
     */
    void Update()
    {
        Collider2D[] objetos = Physics2D.OverlapBoxAll(posicionCaja.position, dimensionesCaja, 0f);
        
        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Player"))
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(sonido);
                colisionador.transform.GetComponent<CombateJugador>().RecuperaVida(vida);
                Destroy(gameObject);
            }
        }
    }

    //Metodo para ver su area de efecto
    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.blue;
        Gizmos.DrawWireCube(controlador.position, dimensionesCaja);
    }
}
