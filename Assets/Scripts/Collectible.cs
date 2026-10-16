using UnityEngine;

public class Collectible : MonoBehaviour
{
    private GameManager gameManager;
    public int collectibleAmount = 1;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayableCharacter player = other.GetComponent<PlayableCharacter>();

        if (player != null)
        {
            if (gameManager != null)
            {
                gameManager.Collect(collectibleAmount);
            }
            Destroy(gameObject);
        }
    }
}
