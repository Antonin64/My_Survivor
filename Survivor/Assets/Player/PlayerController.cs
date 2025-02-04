using UnityEngine;

public class PlayerController : MonoBehaviour
{

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
