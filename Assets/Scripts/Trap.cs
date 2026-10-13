using UnityEngine;

public abstract class Trap : MonoBehaviour, IDamagable
{
    public abstract void ApplyDamage(IDamagable damagable);

    //  Inheritance from IDamagable and implementation of it 
    public void TakeDamage(int howMuch)
    {
        Die();
    }
    public void Die()
    {
        // Destroy the current trap object
        Destroy(gameObject);
    }

    // optional implementation : layerMask whatIDamage
}
