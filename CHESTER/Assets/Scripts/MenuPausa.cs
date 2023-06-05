using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    //Variables
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    public bool juegoPausado = false;

    //Metodo Update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                reanudar();
            }
            else
            {
                pausa();
            }
        }
    }

    //Pausa el juego
    public void pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    //Reaunuda el juego
    public void reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    //Cierra el juego
    public void quitar()
    {
        // Cargar la escena del juego
        SceneManager.LoadScene(0);
    }
}
