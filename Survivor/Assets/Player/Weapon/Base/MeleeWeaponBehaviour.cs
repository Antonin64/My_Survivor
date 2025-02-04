using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptable weaponData;
    public float destroyAfterSeconds;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    protected float curDmg;
    protected float curSpeed;
    protected float curAttSpeed;
    

    void Awake()
    {
        curDmg = weaponData.damage;
        curSpeed = weaponData.speed;
        curAttSpeed = weaponData.attackSpeed;
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Mobs"))
        {
            IEntity entity = col.GetComponent<IEntity>();
            if (entity != null)
            {
                entity.TakeDamage(curDmg);
            }
        }
    }

}
