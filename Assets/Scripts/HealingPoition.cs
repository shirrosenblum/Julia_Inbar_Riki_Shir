using UnityEngine;

public class HealingPoition : Poition
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayableCharacter character = other.GetComponent<PlayableCharacter>();
        if (character != null)
        {
            character.AddHp(hp);
            Destroy(gameObject);
        }
        
    }
}
