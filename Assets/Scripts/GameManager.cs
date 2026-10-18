using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public CinemachineCamera cinemachineCamera; //Camera - to follow the player
    public GameObject[] players;
    public GameObject[] traps;
    public GameObject[] trapSpawnPoints;
    public GameObject[] liveIcons;
    public GameObject WinScreen;
    public GameObject gameoverScreen;
    private GameObject activePlayer;

    public TextMeshProUGUI collectibleCountText;
    private int selectedPlayerIndex;
    private int selectedTrapIndex;

    private int collectibleCount;
    private int allCollectibles;

    private Vector2 startingPlayerPosition = new Vector2(-5, -6);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRandomPlayer();
        SpawnRandomTrap();
        allCollectibles = FindObjectsByType<Collectible>(FindObjectsInactive.Exclude).Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomPlayer()
    {
        // Randomly select player index and instantiate it
        selectedPlayerIndex = Random.Range(0, players.Length);
        activePlayer = Instantiate(players[selectedPlayerIndex], startingPlayerPosition, Quaternion.identity);

        if (cinemachineCamera != null && activePlayer != null)
        {
            cinemachineCamera.Target.TrackingTarget = activePlayer.transform;

        }
    }
    void SpawnRandomTrap()
    {
        // Randomly select trap index and instantiate it in trap spawn points
        for (int i = 0; i < trapSpawnPoints.Length; i++)
        {
            selectedTrapIndex = Random.Range(0, traps.Length);
            Instantiate(traps[selectedTrapIndex], trapSpawnPoints[i].transform.position, Quaternion.identity);
        }
    }

    // This function is called when a next input is detected (currently triggered by Key 2)
    // TODO: Add Player Input component to the GameManager object in the Hierarchy

    void OnNext(InputValue nextValue)
    {
        if (nextValue.isPressed)
        {
            NextPlayer();
        }
    }

    void NextPlayer()
    {
        Vector2 currentPosition = startingPlayerPosition;

        if (activePlayer != null)
        {
            currentPosition = activePlayer.transform.position;
            //Destroys the previous player from the scene
            Destroy(activePlayer);
        }
        //Go through player index cycles in the array 
        selectedPlayerIndex = (selectedPlayerIndex + 1) % players.Length;
        //New selected player
        activePlayer = Instantiate(players[selectedPlayerIndex],currentPosition, Quaternion.identity );

        if (cinemachineCamera != null && activePlayer != null)
        {
            cinemachineCamera.Target.TrackingTarget = activePlayer.transform;
        }
    }

    public void Collect(int amount)
    {
        // Increment the count of collectible objects collected.
        collectibleCount = collectibleCount + amount;
        SetCountText();

        if (collectibleCount >= allCollectibles)
        {
            Win();
        }
    }

    public void SetCountText()
    {
        // Update the count text with the current count.
        if (collectibleCountText != null)
        {
            collectibleCountText.text = collectibleCount.ToString();
        }
    }

    public void UpdateLivesIcons(int currentHp)
    {
        for (int i = 0; i < liveIcons.Length; i++)
        {
            if (i < currentHp)
            {
                liveIcons[i].SetActive(true);
            }
            else
            {
                liveIcons[i].SetActive(false);
            }

        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        Invoke(nameof(ReloadScene), 1.5f);
        gameoverScreen.SetActive(true);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win()
    {
        Debug.Log("Win");
        Invoke(nameof(ReloadScene), 1.5f);
        WinScreen.SetActive(true);
    }
}
