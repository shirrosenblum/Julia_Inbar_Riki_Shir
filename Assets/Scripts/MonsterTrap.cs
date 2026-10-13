using UnityEngine;

public class MonsterTrap : Trap
{
    public override void ApplyDamage(IDamagable damagable)
    {
        if (damagable != null)
        {
            damagable.TakeDamage(1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayableCharacter player = other.gameObject.GetComponent<PlayableCharacter>();

        if (player != null)
        {
            ApplyDamage(player);
        }
    }
}
