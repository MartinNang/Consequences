using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float friction;
    public float hp = 2;
    public Transform playerTransform;
    public Rigidbody2D rb;
    public float dmg;

    Transform t;
    public float fixedRotation;

    // Start is called before the first frame update
    void Start()
    {
        t = transform;
        fixedRotation = t.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        t.eulerAngles = new Vector3(t.eulerAngles.x, t.eulerAngles.y, fixedRotation);
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
        moveTowardsPlayer();
    }

    private void FixedUpdate()
    {
        
    }

    void attackPlayer()
    {

    }

    void moveTowardsPlayer()
    {
        /*
        float angleToPlayer = Mathf.Atan2(transform.position.y - playerTransform.position.y, transform.position.x - playerTransform.position.x);
        Vector2 moveToPlayer = new Vector2(Mathf.Cos(angleToPlayer), Mathf.Sin(angleToPlayer));
        transform.position = moveToPlayer;
        rb.MovePosition(rb.position + moveToPlayer * speed * Time.fixedDeltaTime);*/
        
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
    }

    /*private void OnCollisionEnter2D (Collision2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        

        if (collision.gameObject.tag == "Bullet" )
        {
            hp -= bullet.bulletDamage;
            Destroy(collision.gameObject);
            Debug.Log("Enemy Damage Taken, HP = " + hp);

            if (hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        

    }
    */
    
}
