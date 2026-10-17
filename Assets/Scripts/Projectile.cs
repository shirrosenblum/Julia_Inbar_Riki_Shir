using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    private int damageAmount = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        // Moves the projectile in the given direction with a specified force
        rigidbody2d.AddForce(direction * force);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        MonsterTrap monsterTrap = other.GetComponent<MonsterTrap>();
        //If the projectile hit a monster trap it will deal damage
        if (monsterTrap != null)
        {
            monsterTrap.TakeDamage(damageAmount);
        }
        else
        {
            Debug.Log("eneter");
        }
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //the projectile will destroyed on impact with standard colliders.
        Destroy(gameObject);
    }
}
