using JetBrains.Annotations;
using UnityEngine;

public class Mob_script : MonoBehaviour, IEntity
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private float maxHealth = 100f;
    private Rigidbody2D player;

    public float Damage { get { return damage; } set { damage = value; } }
    public float Health { get { return health; } set { health = value; } }
    public float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }
    public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    private float distance;
    private SpriteRenderer spriterenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        if (direction.x < 0)
        {
            spriterenderer.flipX = true;
        } else
        {
            spriterenderer.flipX = false;
        }
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, movementSpeed * Time.deltaTime);
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            //TODO Handle mob death
        }
    }
}
