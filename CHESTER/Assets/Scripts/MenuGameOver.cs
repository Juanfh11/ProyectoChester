using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    //Metodo para cerrar el juego cuando se pulsa el boton en el menu del final del juego
    public void quitar()
    {
        Debug.Log("cerrando....");
        Application.Quit();
    }

    //metodo para volver al menú principal
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
