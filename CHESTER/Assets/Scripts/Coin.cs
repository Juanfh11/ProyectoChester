using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Variables
    public int valor = 1;
    public GameManager gameManager;
    public AudioClip Sound;
    
    /**
     * Metodo para cuando el jugador toque una moneda se suma el valor al contador,
     * se reproduce el sonido de la moneda y se destruye.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.SumarPuntos(valor);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
            Destroy(this.gameObject);
        }
    }
}
