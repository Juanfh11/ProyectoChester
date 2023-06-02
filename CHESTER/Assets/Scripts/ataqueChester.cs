using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataqueChester : MonoBehaviour
{
    //Variables
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dano;
    private Animator animator;
    [SerializeField] float tiempoEntreAtaque;
    [SerializeField] float tiempoSiguienteAtaque;
    public AudioClip Sound;
    
    
    // Metodo Start
    void Start()
    {
        //Asigno a la variable animator el animator de Chester
        animator=GetComponent<Animator>();
    }

    // Metodo Update
    void Update()
    {
        //Condición para calcular el cooldown del ataque
        if (tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque-=Time.deltaTime;
        }
        
        //Si el cooldown ya es 0 o menor y se hace click con el raton ataca
        if (Input.GetButtonDown("Fire1") && tiempoSiguienteAtaque <=0)
        {
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaque;
        }
    }

    
    /**
     * Metodo Golpe
     * Se llama a este método cuando Chester hace un ataque, en el se activa el sonido
     * y se le resta el daño al enemigo si se le da.
     */
    public void Golpe()
    {
        animator.SetTrigger("Golpe");
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colision in objetos)
        {
            if (colision.CompareTag("enemigo"))
            {
                colision.transform.GetComponent<Boss>().tomarDano(dano);
                
            }
            else if (colision.CompareTag("mago"))
            {
                colision.transform.GetComponent<MagoScript>().tomarDano(dano);
            }
        }
    }

    //Metodo para dibujar el area del golpe del jugador
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
