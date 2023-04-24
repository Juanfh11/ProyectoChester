using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarradeVida : MonoBehaviour
{
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider= GetComponent<Slider>();
    }

    public void cambiarVidaMaxina(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
    }

    public void cambiarVidaActual(float cantidadVida)
    {
        slider.value= cantidadVida;
    }

    public void inicializarBarraDeVida(float cantidadVida)
    {
        cambiarVidaMaxina(cantidadVida);
        cambiarVidaActual(cantidadVida);
    }
}
