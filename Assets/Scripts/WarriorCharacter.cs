using UnityEngine;

public class WarriorCharacter : PlayableCharacter
{

    public GameObject projectilePrefab;
    protected override void SpecialAbility()
    {
        base.SpecialAbility();
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 1f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(moveDirection, 300);
    }
}
