using UnityEngine;

public class WarriorCharacter : PlayableCharacter
{

    public GameObject projectilePrefab;
    protected override void SpecialAbility()
    {
        base.SpecialAbility();

        float distance = 1f;

        // if the Warrior turn right
        if (moveDirection.x > 0)
        {
            distance = 0.5f;
        }
        Vector2 position = (Vector2)rigidbody2d.position + (moveDirection * distance);
        GameObject projectileObject = Instantiate(projectilePrefab, position, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(moveDirection, 350);
    }
}
