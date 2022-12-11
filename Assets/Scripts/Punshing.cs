using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punshing : MonoBehaviour
{
    public float damage = 1;
    public float fireCooldown = 0.5f;
    float fireCooldownRemaining = 0;

    public Animator animator;
    public Transform attackPoint;
    public  float attackRange = 2f;
    public LayerMask enemyLayers;
    Vector2 attackHitBox;



    private void Start()
    {
        attackHitBox = new Vector2(1f, attackRange);
    }
    void Update()
    {
        if (fireCooldownRemaining >= 0)
        {
            fireCooldownRemaining -= Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && fireCooldownRemaining <= 0 && PlayerStatus.hasMelee)
        {
            Punsh();
            fireCooldownRemaining = fireCooldown;
            Debug.Log("Punsh pushed!");
        }

    }

    void Punsh()
    {
        //Play attack Animation
        animator.SetTrigger("MeleeAttack");

        //Detect enemies hit
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, attackHitBox, enemyLayers);

        //Damage 'em
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log("We hit " + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Vector2 attackHitBoxGizmo = new Vector2(0.4f, attackRange);
        Gizmos.DrawWireCube(attackPoint.position, attackHitBoxGizmo);
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
