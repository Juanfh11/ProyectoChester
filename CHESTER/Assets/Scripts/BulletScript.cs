using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //Variables
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    private Vector2 Rotation;
    [SerializeField] private Transform bola;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float danoAtaque;
    private SpriteRenderer sr;
    
    //Metodo Start
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    //Metodo para establecer la velocidad de la bala
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }
    
    //Metodo para establecer la direccion de la bala
    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
        
    }

    //Metodo para destruir la bala
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    /**
     * Metodo que llama al metodo para quitar daño al jugador si choca contra este
     * o que se destruya la bala si choca contra la pared
     */
    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(bola.position,radioAtaque);

        foreach (Collider2D colision in objetos)
        {
            if (colision.CompareTag("Player"))
            {
                colision.GetComponent<CombateJugador>().TomarDano(danoAtaque);
                DestroyBullet();
            }

            if (colision.CompareTag("pared") || colision.CompareTag("ground"))
            {
                DestroyBullet();
            }
        }
    }
}
