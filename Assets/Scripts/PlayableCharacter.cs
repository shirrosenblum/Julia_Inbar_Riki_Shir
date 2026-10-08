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

    // Variables related to player character movement
    [SerializeField] protected Rigidbody2D rigidbody2d;
    public int speed;
    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

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

    public void TakeDamage(int howMuch)
    {
        // TODO: Implement logic later 
    }
    public void Die()
    {
        // TODO: Implement logic later 
    }

    public void Movement()
    {
        // Create a 2D movement vector using the X and Y inputs.
        Vector2 move = new Vector2(movementX, movementY);
        // Apply the new position and move the Rigidbody directly using physics.
        Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    public void ApplyDamage(IDamagable damagable)
    {
        // TODO: Implement logic later
    }

    public void SpecialAbility()
    {
        // TODO: Implement logic later
    }
}
