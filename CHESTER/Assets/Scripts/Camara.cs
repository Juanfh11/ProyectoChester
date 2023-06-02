using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    //Variable
    public GameObject Jugador;
    
    void Update()
    {
        //Cogemos la posición del personaje en el vector X como Y y establecemos la posición de la cámara
        Vector3 position = transform.position;
        position.x = Jugador.transform.position.x;
        transform.position = position;
        position.y = Jugador.transform.position.y;
        transform.position = position;
    }
}
