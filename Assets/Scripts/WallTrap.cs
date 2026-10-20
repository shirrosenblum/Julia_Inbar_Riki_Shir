using UnityEngine;

public class WallTrap : Trap
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
        PlayableCharacter triggerPlayer = other.gameObject.GetComponent<PlayableCharacter>();
        if (triggerPlayer != null && triggerPlayer.speed < 15)
        {
            ApplyDamage(triggerPlayer);
        }
        else
        {
            Invoke("Die", 1f);
        }
    }
}
