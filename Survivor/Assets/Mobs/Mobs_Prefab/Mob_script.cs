using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Mob_script : MonoBehaviour, IEntity
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private float maxHealth = 100f;
    private bool attack;
    private Rigidbody2D player;

    public float Damage { get { return damage; } set { damage = value; } }
    public float Health { get { return health; } set { health = value; } }
    public float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }
    public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    private float distance;
    private SpriteRenderer spriterenderer;
    private Animator animator;
    private EdgeCollider2D hitbox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        hitbox = GetComponentInChildren<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        if (!attack && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetBool("IsAttacking", false);
        }
        if (distance < 0.75 && !attack)
        {
            if (direction.x < 0)
            {
                spriterenderer.flipX = true;
            }
            else
            {
                spriterenderer.flipX = false;
            }
            attack = true;
            animator.SetBool("IsAttacking", true);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Move"))
        {
            
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
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            player.GetComponent<PlayerController>().grantXp(10);
            animator.SetBool("IsDead", true);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    public void AttackCollide()
    {
        hitbox.enabled = true;
    }

    public void AttackUncollide()
    {
        hitbox.enabled = false;
    }

    public void EndAttack()
    {
        attack = false;
    }

    public void SetTarget(Rigidbody2D target)
    {
        player = target;
    }
}
