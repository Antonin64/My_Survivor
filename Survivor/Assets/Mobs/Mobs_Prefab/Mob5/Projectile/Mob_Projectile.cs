using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.DebugUI;

public class Mob_Projectile : MonoBehaviour
{
    private Rigidbody2D player;
    private float damage;
    private Animator animator;
    [SerializeField] private float movementSpeed = 5f;
    private Vector2 direction;
    private float Lifetime = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        direction = (player.position - (Vector2)transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Update is called once per frame
    void Update()
    {
        Lifetime -= Time.deltaTime;
        if (Lifetime < 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Explose"))
        {
            Die();
        }
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Explose"))
        {
            transform.position += (Vector3)direction * Time.deltaTime * movementSpeed;
        }
    }

    public void SetTarget(Rigidbody2D target)
    {
        player = target;
    }

    public void SetDamage(float value)
    {
        damage = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IEntity entity = collision.GetComponent<IEntity>();
            if (entity != null)
            {
                entity.TakeDamage(damage);
                animator.SetBool("Explode", true);
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
