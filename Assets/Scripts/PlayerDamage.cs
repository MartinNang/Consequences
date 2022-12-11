using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public static float playerMaxHP;
    public static float playerMaxHPIncrease;
    public static float playerCurrentHP;

    public float invulnerableTimer = 5;
    private float remainingInvulnerableTime = 0;
    public Animator animator;
       
    void Start()
    {
        playerMaxHP = 10f;
        playerCurrentHP = playerMaxHP;
        Healthbar.SetMaxHealth(playerMaxHP);
        Healthbar.SetHealth(playerCurrentHP);
    }

   
    void Update()
    {
        if (remainingInvulnerableTime > 0)
        {
            remainingInvulnerableTime -= Time.deltaTime;
        }
        animator.SetFloat("InvulnerableTimer", remainingInvulnerableTime);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        

        if (collision.gameObject.tag == "Enemy" && playerCurrentHP <= 1 && remainingInvulnerableTime <=0)
        {
            GameManager.gameOver= true;
                        
            playerCurrentHP -= enemy.dmg;
            Healthbar.SetHealth(playerCurrentHP);
            
            Debug.Log("Damage taken. Player Health = " + playerCurrentHP);
        }
        else if
            (collision.gameObject.tag == "Enemy" && remainingInvulnerableTime <= 0)
        {
            
            playerCurrentHP -= enemy.dmg;
            Healthbar.SetHealth(playerCurrentHP);
            
            remainingInvulnerableTime = invulnerableTimer;
            Debug.Log("Damage taken. Player Health = " + playerCurrentHP);

        }
    }

}
