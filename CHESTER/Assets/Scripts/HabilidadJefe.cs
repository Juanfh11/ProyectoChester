using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadJefe : MonoBehaviour
{
    //Variables
    [SerializeField] private float dano;
    [SerializeField] private Vector2 dimensionesCaja;
    [SerializeField] private Transform posicionCaja;
    [SerializeField] private float tiempoDeVida;
    
    // Metodo Start
    void Start()
    {
        Destroy(gameObject,tiempoDeVida);

    }

    //Metodo que quita vida al jugador principal cuando el enemigo tira la mano con el portal
    public void golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapBoxAll(posicionCaja.position, dimensionesCaja, 0f);

        foreach (Collider2D colisiones in objetos)
        {
            if (colisiones.CompareTag("Player"))
            {
                colisiones.GetComponent<CombateJugador>().TomarDano(dano);
            }
        }
    }

    //Metodo para ver el area del ataque
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(posicionCaja.position, dimensionesCaja);
    }
}
