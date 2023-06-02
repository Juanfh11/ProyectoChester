using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarradeVida : MonoBehaviour
{
    private Slider slider;

    //Método start
    void Start()
    {
        slider= GetComponent<Slider>();
    }

    //Metodo para poner la vida maxima a la barra de vida
    public void cambiarVidaMaxina(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
    }

    //Metodo para cambiar la vida
    public void cambiarVidaActual(float cantidadVida)
    {
        slider.value= cantidadVida;
    }

    //Metodo para inicializar la barra de vida
    public void inicializarBarraDeVida(float cantidadVida)
    {
        cambiarVidaMaxina(cantidadVida);
        cambiarVidaActual(cantidadVida);
    }
}
