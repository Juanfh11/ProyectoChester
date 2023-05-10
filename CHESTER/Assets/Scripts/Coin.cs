using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int valor = 1;
    public GameManager gameManager;
    public AudioClip Sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameManager.SumarPuntos(valor);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
            Destroy(this.gameObject);
        }
        
    }
}
