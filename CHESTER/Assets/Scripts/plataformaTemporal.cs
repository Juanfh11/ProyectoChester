using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaTemporal : MonoBehaviour
{
    //Variables
    [SerializeField] private float tiempoEspera;
    private Rigidbody2D rb;
    [SerializeField] private float velocidadRotacion;
    private bool caida = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //metodo para detectar que el jugador colisiona con la plataforma y esta lanza la corrutina
    //y cuando colisione con el suelo se destruya
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Caida(col));
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }

    //corrutina para para que la plataforma caiga despues de ciertos segundos
    private IEnumerator Caida(Collision2D col)
    {
        yield return new WaitForSeconds(tiempoEspera);
        caida = true;
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), col.transform.GetComponent<Collider2D>());
        rb.constraints = RigidbodyConstraints2D.None;
        rb.AddForce(new Vector2(0.1f, 0));
    }

    //Metodo en el que se realiza la rotacion de la plataforma en cada frame
    void Update()
    {
        if (caida)
        {
            transform.Rotate(new Vector3(0, 0, -velocidadRotacion * Time.deltaTime));
        }
    }
}
