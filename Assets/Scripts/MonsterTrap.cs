using Unity.VisualScripting;
using UnityEngine;

public class MonsterTrap : Trap
{
    public float speed = 3.0f;
    private Rigidbody2D enemyRb;
    private PlayableCharacter player;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            player = FindAnyObjectByType<PlayableCharacter>();
            return;
        }

        Vector2 lookDirection = (player.transform.position - transform.position).normalized;
        Vector2 position = (Vector2)enemyRb.position + lookDirection * speed * Time.deltaTime;
        enemyRb.MovePosition(position);

    }
    public override void ApplyDamage(IDamagable damagable)
    {
        if (damagable != null)
        {
            damagable.TakeDamage(1);
        }
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayableCharacter triggerPlayer = other.gameObject.GetComponent<PlayableCharacter>();

        if (triggerPlayer != null)
        {
            ApplyDamage(triggerPlayer);
        }
    }
}
