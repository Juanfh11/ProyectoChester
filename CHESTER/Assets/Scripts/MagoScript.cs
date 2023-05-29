using Unity.VisualScripting;
using UnityEngine;

public class MagoScript : MonoBehaviour
{
    public GameObject bola;
    public GameObject chester;
    private float LastShoot;
    private bool sprite;
    [Header("Amimación")]
    [SerializeField]private Animator animator;

    public GameObject bulletFire;
    
    [Header("Vida Mago")]
    [SerializeField] private float vida;
    [SerializeField] private BarradeVida barraDeVida;

    public AudioClip sonido;

    private void Update()
    {
        if (chester == null) return;

        Vector3 direction = chester.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(0.02f, 0.02f, 1.0f);
        else
        {
            transform.localScale = new Vector3(-0.02f, 0.02f, 1.0f);
            
        }

        float distanceX = Mathf.Abs(chester.transform.position.x - transform.position.x);
        float distanceY = Mathf.Abs(chester.transform.position.y - transform.position.y);

        if ((distanceX < 2.0f && distanceX > -2.0f) && (Time.time > LastShoot + +2.0f) && ((distanceY < 2.0f) && (distanceY > -2.0f)))
        {
            Shoot(direction);
            LastShoot = Time.time;  
        }
        
    }
    private void Shoot(Vector3 direction)
    {
        GameObject bullet = Instantiate(bola, transform.position + direction * 0.1f, Quaternion.identity);
        if (direction.x >= 0.0f)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
            bullet.GetComponent<SpriteRenderer>().flipX = true;
        }
        
        bullet.GetComponent<BulletScript>().SetDirection(direction);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sonido);
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
