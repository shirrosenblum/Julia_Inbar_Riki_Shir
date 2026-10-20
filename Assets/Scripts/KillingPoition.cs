using UnityEngine;

public class KillingPoition : Poition
{
    public SpriteRenderer spriteRenderer;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayableCharacter character = other.GetComponent<PlayableCharacter>();
        if (character != null)
        {
            character.TakeDamage(hp);
            Destroy(gameObject);
        }
        
    }

    public void Invisible(bool invisible)
    {
        Color newColor = spriteRenderer.color;

        if(invisible)
        {
            newColor.a = 0.5f; 
            spriteRenderer.color = newColor;
        }
        else
        {
            newColor.a = 1f; 
            spriteRenderer.color = newColor;            
        }
    }
}
