using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 1f;
    private Vector2 direction;


    void Start()
    {
        // Destroy the arrow after 3 seconds to prevent issue
        Destroy(gameObject, 3f);
    }

    public void Initialize(Vector2 direction, float damage, Collider2D playerCollider)
    {
        this.direction = direction;
        this.damage = damage;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mobs"))
        {
            IEntity entity = other.GetComponent<IEntity>();
            if (entity != null) {
                entity.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}