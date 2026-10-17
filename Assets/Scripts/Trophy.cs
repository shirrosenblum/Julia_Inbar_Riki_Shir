using UnityEngine;

public class Trophy : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayableCharacter player = other.gameObject.GetComponent<PlayableCharacter>();

        if (player != null)
        {
            Win();
        }
    }

    public void Win()
    {
        gameManager.Win();
        Destroy(gameObject);
    }
}
