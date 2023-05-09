using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadJefe : MonoBehaviour
{
    [SerializeField] private float dano;
    [SerializeField] private Vector2 dimensionesCaja;
    [SerializeField] private Transform posicionCaja;
    [SerializeField] private float tiempoDeVida;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,tiempoDeVida);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(posicionCaja.position, dimensionesCaja);
    }
}
