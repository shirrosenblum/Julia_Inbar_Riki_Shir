using UnityEngine;

public abstract class Trap : MonoBehaviour, IDamagable
{
    public abstract void ApplyDamage(IDamagable damagable);

    //  Inheritance from IDamagable and implementation of it 
    public void TakeDamage(int howMuch)
    {
        // TODO: Implement logic later 
    }
    public void Die()
    {
        // TODO: Implement logic later 
    }
    
    // optional implementation : layerMask whatIDamage
}
