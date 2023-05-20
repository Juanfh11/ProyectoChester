using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puerta : MonoBehaviour
{
    //public GameObject nokey;
    //public GameObject key;

    public Animator animPuerta;

    public AudioClip sonido;
    // Start is called before the first frame update
    void Start()
    {
        //key.SetActive(false);
        //nokey.SetActive(false);
    }

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

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("door") && llave.llavePuntuacion == 0)
        {
            nokey.SetActive(false);
        }

        if (collision.tag.Equals("door") && llave.llavePuntuacion == 1)
        {
            key.SetActive(false);
        }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        /*if (collision.tag.Equals("door") && llave.llavePuntuacion == 0)
        {
            nokey.SetActive(true);
        }*/

        if (collision.tag.Equals("door") && llave.llavePuntuacion == 1)
        {
            //key.SetActive(true);
            animPuerta.SetTrigger("abrir");
            StartCoroutine(WaitForSceneLoad(2));
        }
    }
    
    private IEnumerator WaitForSceneLoad(int seconds) {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(2);
    }
}

