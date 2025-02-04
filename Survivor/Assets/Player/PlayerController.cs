using UnityEngine;

public class PlayerController : MonoBehaviour, IEntity
{
    public float Health { get; set; }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            //TODO Handle player death
        }
    }

    public float movementSpeed;
    float speedX, speedY;
    Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis("Horizontal");
        speedY = Input.GetAxis("Vertical");
        Vector2 mov = new Vector2(speedX, speedY);
        if (mov.magnitude > 1) {mov.Normalize();}
        rb.linearVelocity = mov * movementSpeed;
    }
}
