using UnityEngine;

public class BulletScript : MonoBehaviour
{
    
    public float Speed;
    
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    [SerializeField] private Transform bola;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float danoAtaque;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }
    
    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
    
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
        
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
        }
    }
}
