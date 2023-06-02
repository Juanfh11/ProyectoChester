using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    /*
     * Cuando el jugador choque con el collider del punto de guardado se establece la posición de respawn
     */
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x,transform.position.y);
            GetComponent<Animator>().enabled = true;
        }
    }
}
