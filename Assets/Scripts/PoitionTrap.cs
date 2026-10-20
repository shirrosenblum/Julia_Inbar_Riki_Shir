using UnityEngine;

public class PoitionTrap : MonoBehaviour
{
    public KillingPoition[] poitions;

    void OnTriggerEnter2D (Collider2D other)
    {
        ScholarCharacter character = other.GetComponent<ScholarCharacter>();

        if(character != null)
        {
            foreach (KillingPoition poition in poitions)
            {
                if(poition != null)
                {
                    poition.Invisible(true);
                }
                    
            }   
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        foreach (KillingPoition poition in poitions)
        {
            if(poition != null)
                poition.Invisible(false);
        }   
    }
}
