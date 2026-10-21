using UnityEngine;

public class WallTrap : Trap
{
    private Animator animator;
    [SerializeField] private float speedToPass ;

    void Start()
    {
        animator = GetComponent<Animator>();
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
            if (triggerPlayer.speed < speedToPass)
            {
                ApplyDamage(triggerPlayer);
            }
            else
            {
                Invoke("Die", 1f);
                
                if (animator != null)
                {
                    animator.SetBool("Opened", false);
                }
            }
        }
    }
}
