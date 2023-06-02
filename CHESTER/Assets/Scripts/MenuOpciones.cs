using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
    //Variable
    [SerializeField] private AudioMixer audioMixer;
    
    //Metodo para poner pantalla completa
    public void pantallaCompleta(bool pantalla)
    {
        Screen.fullScreen = pantalla;
    }

    //Metodo para cambiar el volumen
    public void cambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }
}
