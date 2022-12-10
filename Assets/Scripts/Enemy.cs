using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float friction;
    public float hp = 2;
    public GameObject player;
    public float dmg;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Implement Collision Detection
    }

    private void FixedUpdate()
    {
        moveTowardsPlayer();
    }

    void attackPlayer()
    {

    }

    void moveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        Debug.Log("Enemy Damage Taken, HP = " + hp);

        if (collision.gameObject.tag == "Bullet" )
        {
            hp -= bullet.bulletDamage;
            
        }
        

    }

    
}
