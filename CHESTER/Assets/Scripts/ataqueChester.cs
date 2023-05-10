using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataqueChester : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dano;
    private Animator animator;
    [SerializeField] float tiempoEntreAtaque;
    [SerializeField] float tiempoSiguienteAtaque;
    public AudioClip Sound;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque-=Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && tiempoSiguienteAtaque <=0)
        {
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaque;
        }
    }

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
