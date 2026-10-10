using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    private GameObject activePlayer;
    private int selectedPlayerIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRandomPlayer();
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
