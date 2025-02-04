using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public WeaponScriptable weaponData;
    protected Vector3 direction;
    public float destroyAfterSeconds;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionCheck(Vector3 dir)
    {
        direction = dir;
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
         if (col.CompareTag("Mobs"))
        {
            IEntity entity = col.GetComponent<IEntity>();
            if (entity != null) {
                entity.TakeDamage(weaponData.damage);
                Destroy(gameObject);
            }
        }
    }
}
