using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;
using System;
using Unity.Mathematics;

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

    //DIFERENTE VARIABLE GERER POUR LES COMPETEENCE
    [SerializeField] private float armor = 0f;
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float luck = 0f;
    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private int projectileCount = 1;
    [SerializeField] private float fireDamage = 0f;
    [SerializeField] private float iceDamage = 0f;
    [SerializeField] private float poisonDamage = 0f;
    [SerializeField] private float electricDamage = 0f;
    [SerializeField] private float courage = 0f;
    [SerializeField] private float enemyFleeChance = 0f;


    [Header("Weapon")]
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private WeaponScriptable weaponStats;

    public float MaxHealth {get {return maxHealth;} set{maxHealth = value;}}
    public float Damage {get {return damage;} set{damage = value;}}
    public float Health {get {return health;} set{health = value;}}
    public float MovementSpeed { get{return movementSpeed;} set{movementSpeed = value;}}

    public float Armor { get { return armor; } set { armor = value; } }
    public float MaxMana { get { return maxMana; } set { maxMana = value; } }
    public float Luck { get { return luck; } set { luck = value; } }
    public float AttackSpeed { get { return attackSpeed; } set { attackSpeed = value; } }
    public int ProjectileCount { get { return projectileCount; } set { projectileCount = value; } }
    public float FireDamage { get { return fireDamage; } set { fireDamage = value; } }
    public float IceDamage { get { return iceDamage; } set { iceDamage = value; } }
    public float PoisonDamage { get { return poisonDamage; } set { poisonDamage = value; } }
    public float ElectricDamage { get { return electricDamage; } set { electricDamage = value; } }
    public float Courage { get { return courage; } set { courage = value; } }
    public float EnemyFleeChance { get { return enemyFleeChance; } set { enemyFleeChance = value; } }


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


    public double totalXP = 0;
    private double curXp;
    public int level = 1;

    public void grantXp(double xp) {
        curXp += xp;
        totalXP += xp;
        CheckLevelUp();
    }

    public double getXpToNextLevel() {
        return level * 100f + math.pow(3.35f * 10, level);
    }

    private void CheckLevelUp() {
        if (curXp > getXpToNextLevel()) {
            level++;
            curXp = 0;
            Debug.Log("Level up! Level: " + level);
        }
    }

    //GESTION DES IMUNITES
    private HashSet<string> immunities = new HashSet<string>();

    public void GrantImmunity(string element)
    {
        if (!immunities.Contains(element))
        {
            immunities.Add(element);
            Debug.Log("Le joueur est maintenant immunisé à " + element);
        }
    }

    public bool IsImmuneTo(string element)
    {
        return immunities.Contains(element);
    }

    //RENVOIE DES PROJECTILS
    private bool isMeleeReflectActive = false;

    public void EnableMeleeReflect()
    {
        isMeleeReflectActive = true;
        Debug.Log("Renvoi des balles activé !");
    }

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

    //GESTION DES DEGATS ELEMENTAIRE, SWITCH TOUTE LES 3 SECONDE
    public void StartElementSwap(float swapTime)
    {
        StartCoroutine(ElementSwapRoutine(swapTime));
    }

    private IEnumerator ElementSwapRoutine(float swapTime)
    {
        string[] elements = { "Fire", "Ice", "Poison", "Electric" };
        int index = 0;

        while (true)
        {
            ResetElementalDamage();

            switch (elements[index])
            {
                case "Fire": fireDamage = 10f; break;
                case "Ice": iceDamage = 10f; break;
                case "Poison": poisonDamage = 10f; break;
                case "Electric": electricDamage = 10f; break;
            }

            Debug.Log("Élément actif : " + elements[index]);
            index = (index + 1) % elements.Length;
            yield return new WaitForSeconds(swapTime);
        }
    }

    private void ResetElementalDamage()
    {
        fireDamage = 0f;
        iceDamage = 0f;
        poisonDamage = 0f;
        electricDamage = 0f;
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
