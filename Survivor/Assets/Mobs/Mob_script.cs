using UnityEngine;

public class Mob_script : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float damage = 1f;
    public Rigidbody2D player;

    public float Damage { get { return damage; } set { damage = value; } }
    public float Health { get { return health; } set { health = value; } }
    public float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }
    private float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
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
