using UnityEngine;

public class Collectible : MonoBehaviour
{
    private GameManager gameManager;
    private int collectibleAmount = 1;

    private bool isCollected = false;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected)
        {
            return;
        }
        PlayableCharacter player = other.GetComponent<PlayableCharacter>();

        if (player != null)
        {
            isCollected = true;

            if (gameManager != null)
            {
                gameManager.Collect(collectibleAmount);
            }
            Destroy(gameObject);
        }
    }
}
