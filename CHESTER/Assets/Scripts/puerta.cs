using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puerta : MonoBehaviour
{
    //Variables
    public Animator animPuerta;
    public AudioClip sonido;

    //Metodo para que cuando el jugador se acerque a la puerta y este tenga la llave se abra
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("key"))
        {
            llave.llavePuntuacion += 1;
            Destroy(collision.gameObject);
        }
        
        if (collision.tag.Equals("door") && llave.llavePuntuacion == 1)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(sonido);
        }
    }

    //Metodo para abrir la puerta
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("door") && llave.llavePuntuacion == 1)
        {
            animPuerta.SetTrigger("abrir");
            StartCoroutine(WaitForSceneLoad(2));
        }
    }
    
    //Metodo para cargar el menu de final del juego cuando la puerta se abra
    private IEnumerator WaitForSceneLoad(int seconds) {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(2);
    }
}

