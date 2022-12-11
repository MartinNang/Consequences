using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;
    public int bulletHealth;
    public GameObject explosionEffect;
    
    void Awake()
    {
        bulletHealth = 1;
        
        
    }

    
    void Update()
    {
        if(OffScreen())
        {
            Destroy(gameObject);
        }
    }
    public void SetBulletDamage(float damage)
    {
        this.bulletDamage = damage;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (collision.gameObject.tag == "Enemy" && bulletHealth >= 1)
        {
            bulletHealth --;
            Debug.Log("Bullet hit enemy!");

            enemy.hp -= bulletDamage;

            Destroy(this.gameObject);
        }*/
        GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f); 
        GameObject enemy = collision.gameObject;

        if (enemy.tag == "Enemy" && bulletHealth >= 1)
        {
            enemy.GetComponent<Enemy>().TakeDamage(bulletDamage);
            Debug.Log("Bullet hit enemy!");

            Destroy(this.gameObject);



        }
    }
    bool OffScreen()
    {
        if (transform.position.y >= 8 || transform.position.y <=-8 || transform.position.x >= 15 || transform.position.x <= -15)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
