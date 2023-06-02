using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntosMonedas : MonoBehaviour
{
    //Variables
    public GameManager gameManager;
    public TextMeshProUGUI puntos;

    // Metodo Update, imprime por pantalla los puntos que tienes
    void Update()
    {
        puntos.text = gameManager.PuntosTotales.ToString();
    }
}
