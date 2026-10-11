using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] traps;
    public GameObject[] trapSpawnPoints;
    private GameObject activePlayer;
    private int selectedPlayerIndex;
    private int selectedTrapIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRandomPlayer();
        SpawnRandomTrap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomPlayer()
    {
        // Randomly select player index and instantiate it
        selectedPlayerIndex = Random.Range(0, players.Length);
        activePlayer = Instantiate(players[selectedPlayerIndex]);
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
        if (activePlayer != null)
        {
            //Destroys the previous player from the scene
            Destroy(activePlayer);
        }
        //Go through player index cycles in the array 
        selectedPlayerIndex = (selectedPlayerIndex + 1) % players.Length;
        //New selected player
        activePlayer = Instantiate(players[selectedPlayerIndex]);
    }
}
