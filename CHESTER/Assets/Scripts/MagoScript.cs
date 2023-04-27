using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MagoScript : MonoBehaviour
{
    public GameObject bola;
    public GameObject chester;
    private float LastShoot;
    
    private Animator animator;
    
    [Header("Vida")]
    [SerializeField] private float vida;
    [SerializeField] private BarradeVida barraDeVida;

    private void Update()
    {
        if (chester == null) return;

        Vector3 direction = chester.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(0.02f, 0.02f, 1.0f);
        else transform.localScale = new Vector3(-0.02f, 0.02f, 1.0f);

        float distance = Mathf.Abs(chester.transform.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot + +0.25f)
        {
            Shoot();
            LastShoot = Time.time;  
        }

        
    }
    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(bola, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
    
    public void tomarDano(float dano)
    {
        vida -= dano;
        barraDeVida.cambiarVidaActual(vida);
        if (vida<=0)
        {
            animator.SetTrigger("Die");
        }
    }
    
    private void Muerte()
    {
        Destroy(gameObject);
    }

}
