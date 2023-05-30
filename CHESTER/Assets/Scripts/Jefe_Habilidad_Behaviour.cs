using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe_Habilidad_Behaviour : StateMachineBehaviour
{
    
    [SerializeField] private GameObject habilidad;
    [SerializeField] private float offsetY;
    private Boss jefe;
    private Transform jugador;
    public AudioClip sonido;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jefe = animator.GetComponent<Boss>();
        jugador = jefe.jugador;
        jefe.mirarJugador();
        Vector2 posicionAparicion = new Vector2(jugador.position.x, jugador.position.y + offsetY);
        Instantiate(habilidad,posicionAparicion,Quaternion.identity);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sonido);
    }
}
