using UnityEngine;

public class PlayerController : MonoBehaviour, IEntity
{


    //ENTITY VARIABLES
    [SerializeField] private float health = 100f;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float damage = 1f;

    public float MaxHealth {get {return maxHealth;} set{maxHealth = value;}}
    public float Damage {get {return damage;} set{damage = value;}}
    public float Health {get {return health;} set{health = value;}}
    public float MovementSpeed { get{return movementSpeed;} set{movementSpeed = value;}}

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            //TODO Handle player death
        }
    }


    //PRIVATE VARIABLES
    float speedX, speedY;
    Rigidbody2D rb;
    SpriteRenderer sr;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis("Horizontal");
        speedY = Input.GetAxis("Vertical");
        if (speedX < 0)
        {
            sr.flipX = true;
        }
        else if (speedX > 0)
        {
            sr.flipX = false;
        }
        Vector2 mov = new Vector2(speedX, speedY);
        if (mov.magnitude > 1) {mov.Normalize();}
        rb.linearVelocity = mov * movementSpeed;
    }
}
