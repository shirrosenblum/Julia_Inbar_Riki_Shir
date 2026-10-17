using UnityEngine;

public class ScholarCharacter : PlayableCharacter
{
    //public KillingPoition[] poitions;
    // TODO: Implement logic later
    void Start()
    {
        ShowKillingPotions();
    }
    void OnEnable()
    {
        ShowKillingPotions();
    }

    void OnDisable()
    {
        KillingPoition[] poitions = Object.FindObjectsByType<KillingPoition>();
        foreach (KillingPoition poition in poitions)
        {
            if(poition != null)
                poition.Invisible(false);
        }        
    }

    void ShowKillingPotions()
    {
        KillingPoition[] poitions = Object.FindObjectsByType<KillingPoition>();
        foreach (KillingPoition poition in poitions)
        {
            if(poition != null)
                poition.Invisible(true);
        }        
    }
}
