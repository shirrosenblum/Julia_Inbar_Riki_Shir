using System;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayableCharacter : MonoBehaviour, IDamagable
{
    public int maxHp;
    // getting the value of the currentHp private variable
    public int health { get { return currentHp; } }
    private int currentHp;

    private GameManager gameManager;


    // Variables related to player character movement
    [SerializeField] protected Rigidbody2D rigidbody2d;
    public int speed;

    public Vector2 moveDirection = new Vector2(1, 0);
    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    void Start()
    {
        //Sets the current health to the maximum health points when the game starts
        currentHp = maxHp;

        gameManager = FindAnyObjectByType<GameManager>();
    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // FixedUpdate has the same call rate as the physics system 
    void FixedUpdate()
    {
        Movement();
    }

    void OnAttack(InputValue attackValue)
    {
        SpecialAbility();
    }

    public void TakeDamage(int howMuch)
    {
        currentHp = currentHp - howMuch;
        // Lose condition
        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void AddHp(int howMuch)
    {
        currentHp = currentHp + howMuch;
        // Lose condition
        if (currentHp >maxHp)
        {
            currentHp = maxHp;
        }
    }

    public void Die()
    {
        // Destroy the current player object
        Destroy(gameObject);
        // Reload the scene
        if (gameManager != null)
        {
            gameManager.GameOver();
        }
    }
    public void Movement()
    {
        // Create a 2D movement vector using the X and Y inputs.
        Vector2 move = new Vector2(movementX, movementY);
        // Apply the new position and move the Rigidbody directly using physics.
        Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);

        // Checks if there is  movement 
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();
        }
    }

    public void ApplyDamage(IDamagable damagable)
    {
        if (damagable != null)
        {
            damagable.TakeDamage(1);
        }
    }

    protected virtual void SpecialAbility()
    {

    }
}
