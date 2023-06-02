using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variables
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;

    //Metodo para sumar puntos con las monedas
    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
    }
}