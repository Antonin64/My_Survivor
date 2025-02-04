using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private Collider2D hitbox;
    void Start()
    {
        hitbox = GetComponent<Collider2D>();
        hitbox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("caca");
            IEntity entity = collision.GetComponent<IEntity>();
            if (entity != null)
            {
                entity.TakeDamage(GetComponentInParent<IEntity>().Damage);
                hitbox.enabled = false;
            }
        }
    }
}
