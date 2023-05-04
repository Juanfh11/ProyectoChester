using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class pocion : MonoBehaviour
{
    [SerializeField] private Transform controlador;

    [SerializeField] private GameObject player;

    Rigidbody2D rigidbody2D;

    [SerializeField] private Vector2 dimensionesCaja;
    [SerializeField] private Transform posicionCaja;

    [SerializeField] private int vida;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        Collider2D[] objetos = Physics2D.OverlapBoxAll(posicionCaja.position, dimensionesCaja, 0f);


        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Player"))
            {
                colisionador.transform.GetComponent<CombateJugador>().RecuperaVida(vida);
                Destroy(gameObject);
            }

        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.blue;

        Gizmos.DrawWireCube(controlador.position, dimensionesCaja);

    }
}
