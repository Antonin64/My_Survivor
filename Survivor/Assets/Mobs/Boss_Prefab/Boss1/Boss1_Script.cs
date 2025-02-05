using UnityEngine;

public class Boss1_Script : MonoBehaviour
{
    [SerializeField] private float health = 2000f;
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float movementSpeedAttacking = 10f;
    [SerializeField] private float damage = 20f;
    [SerializeField] private float maxHealth = 2000f;
    private int attack;
    [SerializeField] private Rigidbody2D player;

    public float Damage { get { return damage; } set { damage = value; } }
    public float Health { get { return health; } set { health = value; } }
    public float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }
    public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    private SpriteRenderer spriterenderer;
    private Animator animator;
    private BoxCollider2D hitbox;
    private float timer;
    private bool tookDamage;
    private Vector2 directionAttack;
    private float movementSpeedAttackingRuntime;
    [SerializeField] private int minTimeAttack = 2;
    [SerializeField] private int maxTimeAttack = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attack = 0;
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        hitbox = GetComponent<BoxCollider2D>();
        tookDamage = false;
        timer = Random.Range(minTimeAttack, maxTimeAttack);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        if (attack <= 0 && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetBool("IsAttacking", false);
            timer = Random.Range(minTimeAttack, maxTimeAttack);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && attack > 0)
        {
            transform.Translate(movementSpeedAttackingRuntime * Time.deltaTime * directionAttack);
        }
        if (timer < 0 && attack <= 0)
        {
            if (direction.x < 0)
            {
                spriterenderer.flipX = true;
            }
            else
            {
                spriterenderer.flipX = false;
            }
            attack = 3;
            directionAttack = direction;
            directionAttack.Normalize();
            tookDamage = false;
            animator.SetBool("IsAttacking", true);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Move"))
        {
            timer -= Time.deltaTime;
            if (direction.x < 0)
            {
                spriterenderer.flipX = true;
            }
            else
            {
                spriterenderer.flipX = false;
            }
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, movementSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tookDamage == false)
        {
            if (collision.CompareTag("Player"))
            {
                IEntity entity = collision.GetComponent<IEntity>();
                if (entity != null)
                {
                    entity.TakeDamage(Damage);
                    tookDamage = true;
                }
            }
        }
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            animator.SetBool("IsDead", true);
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    public void IsSlashing()
    {
        movementSpeedAttackingRuntime = movementSpeedAttacking;
    }
    public void IsNotSlashing()
    {
        movementSpeedAttackingRuntime = 0;
    }
    public void EndAttack()
    {
        Vector2 direction = player.transform.position - transform.position;
        directionAttack = direction;
        if (direction.x < 0)
        {
            spriterenderer.flipX = true;
        }
        else
        {
            spriterenderer.flipX = false;
        }
        directionAttack.Normalize();
        tookDamage = false;
        attack -= 1;
    }
    public void SetTarget(Rigidbody2D target)
    {
        player = target;
    }
}
