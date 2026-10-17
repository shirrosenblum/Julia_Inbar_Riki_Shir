using UnityEngine;

public class ScholarCharacter : PlayableCharacter
{
    public KillingPoition[] poitions;
    // TODO: Implement logic later

    void OnEnable()
    {
        foreach (KillingPoition poition in poitions)
        {
            if(poition != null)
                poition.Invisible(true);
        }
    }

    void OnDisable()
    {
        foreach (KillingPoition poition in poitions)
        {
            if(poition != null)
                poition.Invisible(false);
        }        
    }
}
