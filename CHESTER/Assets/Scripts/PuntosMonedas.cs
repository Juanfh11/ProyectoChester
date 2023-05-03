using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntosMonedas : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI puntos;

    // Update is called once per frame
    void Update()
    {
        puntos.text = gameManager.PuntosTotales.ToString();
    }
}
