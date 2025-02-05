using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System;

enum AttackType
{
    Slash,
    Arrow,
    Magic
}

public class PlayerController : MonoBehaviour, IEntity
{


    //ENTITY VARIABLES
    [SerializeField] private float health = 100f;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private float attackRange = 10f;

    [Header("Weapon")]
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private WeaponScriptable weaponStats;

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

    //public Variables
    [HideInInspector] public Vector2 lastMoveDir;
    [HideInInspector] public Vector3 nearestEnemyPos;


    //PRIVATE VARIABLES
    Vector2 movDir;
    Rigidbody2D rb;
    SpriteRenderer sr;
    private bool canAttack = true;
    private Collider2D playerCollider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
        StartCoroutine(AttackRoutine());
        Type controllertype = weaponController.GetType();
        weaponController = (WeaponController)gameObject.AddComponent(controllertype);
        weaponController.pc = this;
        weaponController.weaponStats = weaponStats;
    }

    // Update is called once per frame
    void Update()
    {
        InputManager();
    }

    void FixedUpdate()
    {
        Move();
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (canAttack)
            {
                //Attack();
                nearestEnemyPos = Vector3.zero;
                //Find nearest enemy
                GameObject nearestEnemy = FindNearestEnemy();
                if (nearestEnemy != null)
                {
                    nearestEnemyPos = nearestEnemy.transform.position;
                }

                //Coodlown
                canAttack = false;
                yield return new WaitForSeconds(1f);
                canAttack = true;
            }
            yield return null;
        }
    }

    GameObject FindNearestEnemy()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);
        GameObject nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Mobs"))
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = collider.gameObject;
                }
            }
        }

        return nearestEnemy;
    }

    void InputManager()
    {
        float speedX = Input.GetAxis("Horizontal");
        float speedY = Input.GetAxis("Vertical");

        if (speedX < 0) // turn player to where it goes
            {sr.flipX = true;}
        else if (speedX > 0)
            {sr.flipX = false;}

        movDir = new Vector2(speedX, speedY);
        if (movDir.magnitude > 1) {movDir.Normalize();}
        if (movDir != Vector2.zero)
            lastMoveDir = movDir;
    }

    void Move()
    {
        rb.linearVelocity = movDir * movementSpeed;
    }
}
